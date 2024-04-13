﻿using AnimalCrudApi.Animals.Model;
using AnimalCrudApi.Dto;

namespace AnimalCrudApi.Animals.Service.Interfaces
{
    public interface IAnimalCommandService
    {
        Task<Animal> CreateAnimal(CreateAnimalRequest animalRequest);
        Task<Animal> UpdateAnimal(UpdateAnimalRequest animalRequest);
        Task<Animal> DeleteAnimal(int id);
    }
}
