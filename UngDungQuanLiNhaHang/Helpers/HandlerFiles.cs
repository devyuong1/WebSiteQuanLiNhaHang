using System.IO;
using System.Threading.Tasks;

namespace UngDungQuanLiNhaHang.Helpers {
    public class HandlerFiles {
        private readonly IWebHostEnvironment _env;

        public HandlerFiles(IWebHostEnvironment env) {
            _env = env;
        }
        public async Task<string> SaveFile(IFormFile file,string folder) {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string relativePath = Path.Combine("images", folder, fileName);// => "images/products/xxx.jpg"
            string absolutePath = Path.Combine(_env.WebRootPath, relativePath);// => "/wwwroot/images/products/xxx.jpg"
            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath)!);
            using var stream = new FileStream(absolutePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return relativePath.Replace("\\", "/");// => "/images/products/xxx.jpg"


        }
        public void DeleteFile(string path) {
            var fullPath = Path.Combine(_env.WebRootPath, path.Replace("/", Path.DirectorySeparatorChar.ToString()));
            if ( File.Exists(fullPath) ) File.Delete(fullPath);
        }
    }
}
