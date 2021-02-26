using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        //IFormFile dosya işlemleri için. Bu örnekte resim yüklemek için kullanıldı.
        [HttpPost("add")]
        public async Task<string> Add([FromForm] IFormFile uploadImages, [FromForm] CarImage carImage)
        {

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(uploadImages.FileName);
            string fileExtension = fileInfo.Extension;

            var imagePath = Path.GetTempFileName();
            if (uploadImages.Length > 0)
            {
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    await uploadImages.CopyToAsync(fileStream);
            }
            var addedCarImage = new CarImage { CarId = carImage.CarId, ImagePath = imagePath, Date = DateTime.Now };
            var result = _carImageService.Add(addedCarImage, fileExtension);

            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost("update")]
        public async Task<string> Update([FromForm] IFormFile uploadImages, [FromForm] CarImage carImage)
        {
            var deleteOldImagePath = carImage.ImagePath;

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(uploadImages.FileName);
            string fileExtension = fileInfo.Extension;

            var imagePath = Path.GetTempFileName();
            if (uploadImages.Length > 0)
            {
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    await uploadImages.CopyToAsync(fileStream);
            }
            var updatedCarImage = new CarImage { Id=carImage.Id, CarId = carImage.CarId, ImagePath = imagePath, Date = DateTime.Now };
            var result = _carImageService.Update(updatedCarImage, deleteOldImagePath, fileExtension);

            if (result.Success)
            {
                return result.Message;
            }
            return result.Message;
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByCarImageId(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarIdImage(int carId)
        {
            var result = _carImageService.GetByCarIdImage(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
