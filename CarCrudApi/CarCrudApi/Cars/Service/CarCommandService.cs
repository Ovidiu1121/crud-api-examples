﻿using CarCrudApi.Cars.Model;
using CarCrudApi.Cars.Repository.interfaces;
using CarCrudApi.Cars.Service.Interfaces;
using CarCrudApi.Dto;
using CarCrudApi.System.Constant;
using CarCrudApi.System.Exceptions;

namespace CarCrudApi.Cars.Service
{
    public class CarCommandService:ICarCommandService
    {
        private ICarRepository _repository;

        public CarCommandService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<Car> CreateCar(CreateCarRequest request)
        {
            if (request.Price<0)
            {
                throw new InvalidPrice(Constants.INVALID_PRICE);
            }

            Car car = await _repository.GetByBrandAsync(request.Brand);

            if (car!=null)
            {
                throw new ItemAlreadyExists(Constants.CAR_ALREADY_EXIST);
            }

            car=await _repository.CreateCar(request);
            return car;
        }

        public async Task<Car> DeleteCar(int id)
        {
            Car car = await _repository.GetByIdAsync(id);

            if (car!=null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            await _repository.DeleteCarById(id);
            return car;
        }

        public async Task<Car> UpdateCar(UpdateCarRequest request)
        {
            if (request.Price<0)
            {
                throw new InvalidPrice(Constants.INVALID_PRICE);
            }

            Car car = await _repository.GetByBrandAsync(request.Brand);

            if (car!=null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            car = await _repository.UpdateCar(request);
            return car;
        }
    }
}
