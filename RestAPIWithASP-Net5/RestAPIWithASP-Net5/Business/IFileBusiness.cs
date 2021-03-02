using Microsoft.AspNetCore.Http;
using RestAPIWithASP_Net5.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files);
    }
}
