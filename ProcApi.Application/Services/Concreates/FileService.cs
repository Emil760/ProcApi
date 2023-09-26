using Microsoft.Extensions.Options;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Options;
using FileOptions = ProcApi.Infrastructure.Options.FileOptions;

namespace ProcApi.Application.Services.Concreates
{
    //TODO files
    public class FileService : IFileService
    {
        private readonly FilePaths _filePaths;
        private readonly FileOptions _fileOptions;

        public FileService(IOptions<FilePaths> filePaths,
            IOptions<FileOptions> fileOptions)
        {
            _filePaths = filePaths.Value;
            _fileOptions = fileOptions.Value;
        }
    }
}