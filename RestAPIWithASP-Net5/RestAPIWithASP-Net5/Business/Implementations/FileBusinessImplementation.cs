using Microsoft.AspNetCore.Http;
using RestAPIWithASP_Net5.Data.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Business.Implementations
{
    public class FileBusinessImplementation : IFileBusiness
    {
        private readonly string BasePath;
        private readonly IHttpContextAccessor Context;

        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            BasePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
            Context = context;
        }

        public byte[] GetFile(string fileName)
        {
            var result = BasePath + fileName;
            return File.ReadAllBytes(result);
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();
            var fileType = Path.GetExtension(file.FileName);
            //AQUI VOU BUSCAR A URL BASE DO HOST QUE CARREGA O FICHEIRO
            var Url = Context.HttpContext.Request.Host;

            if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
            {
                var docName = Path.GetFileName(file.FileName);
                if(docName != null)
                {
                    var destination = Path.Combine(BasePath + "" + docName);
                    fileDetail.DocType = fileType;
                    fileDetail.DocumentName = docName;
                    fileDetail.DocUrl = Path.Combine(Url + "/api/file/v1/" + fileDetail.DocumentName);

                    await using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
            return fileDetail;
        }

        public async Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files)
        {
            if (files == null) return null;
            List<FileDetailVO> fileDetailVOs = new List<FileDetailVO>();

            foreach (var item in files)
            {
                var fileType = Path.GetExtension(item.FileName);
                var Url = Context.HttpContext.Request.Host;

                if(fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
                {
                    var docName = Path.GetFileName(item.FileName);
                    if(docName != null)
                    {
                        var destination = Path.Combine(BasePath + "" + docName);
                        fileDetailVOs.Add(new FileDetailVO
                        {
                            DocType = fileType,
                            DocumentName = docName,
                            DocUrl = Path.Combine(Url + "/api/file/v1/" + docName)
                        });

                        await using var stream = new FileStream(destination, FileMode.Create);
                        await item.CopyToAsync(stream);
                    }
                }
            }
            return fileDetailVOs;
        }
    }
}
