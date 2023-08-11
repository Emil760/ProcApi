using Microsoft.Extensions.Options;
using ProcApi.Configurations.Options;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class FileService : IFileService
    {
        private readonly FilePaths _filePaths;
        private readonly Configurations.Options.FileOptions _fileOptions;

        public FileService(IOptions<FilePaths> filePaths,
            IOptions<Configurations.Options.FileOptions> fileOptions)
        {
            _filePaths = filePaths.Value;
            _fileOptions = fileOptions.Value;
        }
    }
}