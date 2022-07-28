using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Contracts;
using System.Net.Http.Headers;

namespace WepAPI.Controllers
{
    public class PostImageController : APIBaseController
    {
        private readonly IPostImageService _postimageService;


        public PostImageController(IPostImageService postimageService)
        {
            _postimageService = postimageService;
        }

        // GET Images
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            IEnumerable<PostImageDTO> postimageDTO = _postimageService.GetAll();
            return Ok(postimageDTO);
        }
        // GET Images
        [HttpGet]
        [Route("getallbyid/{id}")]
        public IActionResult GetAll(int id)
        {
            IEnumerable<PostImageDTO> postimageDTO = _postimageService.GetAll(id);
            return Ok(postimageDTO);
        }

        // GET post image with id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_postimageService.ImageExists(id))
            {
                return NotFound();
            }

            PostImageDTO postimageDTO = _postimageService.GetById(id);
            return Ok(postimageDTO);
        }

        // POST PostImage
        [HttpPost]
        [Route("{id}")]
        public IActionResult Add(int id, string[] dbPath)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<PostImageDTO> postimagesDTO = null;
            foreach (var path in dbPath) {
                PostImageDTO postimageDTO = new PostImageDTO();
                postimageDTO.PostId = id;
                postimageDTO.ImageURL = path;
                _postimageService.Add(postimageDTO);
                postimagesDTO.Append(postimageDTO);
                    }
            _postimageService.SavePostImage();
            return Ok(postimagesDTO);
        }

        // PUT PostImage
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, PostImageDTO postimageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postimageDTO.PostImageID)
            {
                return BadRequest();
            }

            if (!_postimageService.ImageExists(id))
            {
                return NotFound();
            }

            _postimageService.Update(id, postimageDTO);
            _postimageService.SavePostImage();
            return Ok(postimageDTO);
        }

        // DELETE Location/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_postimageService.ImageExists(id))
            {
                return NotFound();
            }
            _postimageService.Delete(id);
            _postimageService.SavePostImage();
            return Ok("Post Image deleted");
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("")]
        public async Task<IActionResult> UploadFiles()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var files = formCollection.Files;
                string folderName = Path.Combine("Resorces", "Images");
                string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string[] dbPath=null;
                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        try
                        {
                            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            string fullPath = Path.Combine(pathToSave, fileName);
                            dbPath.Append(Path.Combine(folderName, fileName));

                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500, $"Internal server error: {ex}");
                        }
                    }
                    else
                    {
                        return BadRequest();

                    }

                }
                if (dbPath.Length>0)
                    return Ok(new { dbPath });
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



    }
}
