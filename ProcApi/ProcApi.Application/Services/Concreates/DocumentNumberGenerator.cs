using Microsoft.Extensions.Localization;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Utility;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;
using System.Text;

namespace ProcApi.Application.Services.Concreates
{
    public class DocumentNumberGenerator : IDocumentNumberGenerator
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentNumberSectionRepository _documentNumberSectionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public DocumentNumberGenerator(IDocumentRepository documentRepository,
            IDocumentNumberSectionRepository documentNumberSectionRepository,
            IStringLocalizer<SharedResource> localizer,
            IUserRepository userRepository)
        {
            _documentRepository = documentRepository;
            _documentNumberSectionRepository = documentNumberSectionRepository;
            _localizer = localizer;
            _userRepository = userRepository;
        }

        public async Task<string> GenerateDocumentNumber(int docId, DocumentType documentType)
        {
            StringBuilder number = new StringBuilder();

            var sections = await _documentNumberSectionRepository.GetActiveSectionsByTypeAsync(documentType);

            if (!sections.Any())
                throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NUMBER_SECTION_NOT_FOUND]);

            var lastSection = sections.Last();

            foreach (var section in sections)
            {
                switch (section.SectionType)
                {
                    case DocumentNumberSectionType.Number:
                        number.Append(await GenerateByCountAsync(docId, documentType));
                        break;

                    case DocumentNumberSectionType.Date:
                        number.Append(await GenerateByDate(docId, section.Format));
                        break;

                    case DocumentNumberSectionType.Author:
                        number.Append(await GenerateByAuthorAsync(docId, section.Format));
                        break;

                    case DocumentNumberSectionType.DocumentType:
                        number.Append(GenerateByDocumentType(documentType));
                        break;

                    case DocumentNumberSectionType.Text:
                        number.Append(GenerateByText(section.Value));
                        break;

                    default:
                        break;
                }

                if (section != lastSection)
                    number.Append(section.Delimiter);
            }

            return number.ToString();
        }

        public async Task<string> GenerateByCountAsync(int docId, DocumentType documentType)
        {
            return (await _documentRepository.GetCountByTypeAsync(documentType)).ToString();
        }

        public async Task<string> GenerateByAuthorAsync(int docId, string format)
        {
            var author = await _userRepository.GetDocumentAuthor(docId);

            if (author is null)
                throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND]);

            var result = UserFormatUtility.FormatUser(author.FirstName, author.LastName, "", format);
            return result;
        }

        public async Task<string> GenerateByDate(int docId, string format)
        {
            var document = await _documentRepository.GetByIdAsync(docId);

            if (document is null)
                throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

            return document.CreatedOn.ToString(format);
        }

        public string GenerateByText(string value)
        {
            return value;
        }

        public string GenerateByDocumentType(DocumentType documentType)
        {
            return documentType.GetDescription();
        }
    }
}
