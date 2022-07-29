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
        /*[HttpPost]
        [Route("{id}")]
        public IActionResult Add(int id, List<string> dbPath)
        {
            //id here stands for post id
            IEnumerable<PostImageDTO> postimagesDTO = Enumerable.Empty<PostImageDTO>();
            foreach (var path in dbPath) {
                PostImageDTO postimageDTO = new PostImageDTO();
                postimageDTO.PostId = id;
                postimageDTO.ImageURL = path;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _postimageService.Add(postimageDTO);
                postimagesDTO.Append(postimageDTO);
                    }
            _postimageService.SavePostImage();
            return Ok(postimagesDTO); 
        }*/
        [HttpPost]
        [Route("")]
        public IActionResult Add(PostImageDTO postimageDTO)
        {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            _postimageService.Add(postimageDTO);
            _postimageService.SavePostImage();
            return Ok(postimageDTO);
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
        /*[HttpPost, DisableRequestSizeLimit]
        [Route("why")]*/
        /*public async Task<IActionResult> UploadFiles()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var files = formCollection.Files;
                string folderName = Path.Combine("Resorces", "Images");
                string pathToSave = Path.Combine("../", folderName);
                var dbPaths = new List<string>();

                *//*List<string> dbPaths = new List<string> { };*//*
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
                            var dbpath = Path.Combine(folderName, fileName);
                            if (dbpath.Length > 0){
                                dbPaths.Append(dbpath);
                                using (var stream = new FileStream(fullPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500, $"Internal server error:  {ex}");
                        }
                    }
                    else
                    {
                        return BadRequest();

                    }

                }
                if (dbPaths.Count > 0)
                    return Ok(new { dbPaths });
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }*/
        [HttpPost, DisableRequestSizeLimit]
        [Route("why")]
        public IActionResult Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resorces", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var dbPaths = new List<string>();
                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    dbPaths.Add(dbPath);

                }

                return Ok(new { dbPaths });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }



    }
}
