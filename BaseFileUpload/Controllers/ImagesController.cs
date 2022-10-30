using BaseFileUpload.DataAccess.Abstract;
using BaseFileUpload.Entities; 
using Microsoft.AspNetCore.Mvc;

namespace BaseFileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageDal _imageDal;
        public ImagesController(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        [HttpPost("uploadimage")]
        public IActionResult UploadImage([FromForm] ImageEntity entity)
        {
            _imageDal.Add(entity);
            return Ok();
        }

        [HttpPut("updateimage")]
        public IActionResult UpdateImage([FromForm] ImageEntity entity)
        {
            _imageDal.Update(entity);
            return Ok();
        }

        [HttpDelete("removeimage")]
        public IActionResult RemoveImage(int id)
        {
            _imageDal.Delete(id);
            return Ok();
        }

        [HttpGet("getallimage")]
        public IActionResult GetAll()
        {
            var result= _imageDal.GetAll();
            return Ok(result);
        }
        [HttpGet("getbyfilter")]
        public IActionResult GetByFilter(int id)
        {
            var result = _imageDal.Get(x=>x.Id==id);
            return Ok(result);
        }

    }
}
