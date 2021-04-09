using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredCreditCardsController : ControllerBase
    {
        IRegisteredCreditCardService _registeredCreditCardService;
        public RegisteredCreditCardsController(IRegisteredCreditCardService registeredCreditCardService)
        {
            _registeredCreditCardService = registeredCreditCardService;
        }


        [HttpPost("add")]
        public IActionResult Add(RegisteredCreditCard registeredCreditCard)
        {
            var result = _registeredCreditCardService.Add(registeredCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(RegisteredCreditCard registeredCreditCard)
        {
            var result = _registeredCreditCardService.Delete(registeredCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(RegisteredCreditCard registeredCreditCard)
        {
            var result = _registeredCreditCardService.Update(registeredCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _registeredCreditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _registeredCreditCardService.GetByRegisteredCreditCardId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _registeredCreditCardService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getisregisteredcreditcard")]
        public IActionResult isRegisteredCreditCard(RegisteredCreditCard registeredCreditCard)
        {
            var result = _registeredCreditCardService.isRegisteredCreditCard(registeredCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
