﻿using CarCrudApi.Cars.Controllers.Interfaces;
using CarCrudApi.Cars.Model;
using CarCrudApi.Cars.Repository.interfaces;
using CarCrudApi.Cars.Service.Interfaces;
using CarCrudApi.Dto;
using CarCrudApi.System.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CarCrudApi.Cars.Controllers
{
    public class CarController:CarApiController
    {
        private ICarCommandService _carCommandService;
        private ICarQueryService _carQueryService;

        public CarController(ICarCommandService carCommandService, ICarQueryService carQueryService)
        {
            _carCommandService = carCommandService;
            _carQueryService = carQueryService;
        }

        public override async Task<ActionResult<Car>> CreateCar([FromBody] CreateCarRequest request)
        {
            try
            {
                var cars = await _carCommandService.CreateCar(request);

                return Ok(cars);
            }
            catch (InvalidPrice ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ItemAlreadyExists ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<Car>> DeleteCar([FromRoute] int id)
        {
            try
            {
                var cars = await _carCommandService.DeleteCar(id);

                return Accepted("", cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            try
            {
                var cars = await _carQueryService.GetAllCar();
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Car>> GetByBrandRoute([FromRoute] string brand)
        {
            try
            {
                var cars = await _carQueryService.GetByBrand(brand);
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<Car>> UpdateCar([FromBody] UpdateCarRequest request)
        {
            try
            {
                var cars = await _carCommandService.UpdateCar(request);

                return Ok(cars);
            }
            catch (InvalidPrice ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
