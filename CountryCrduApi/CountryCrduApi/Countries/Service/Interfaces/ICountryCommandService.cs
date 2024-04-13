﻿using CountryCrduApi.Countries.Model;
using CountryCrduApi.Dto;

namespace CountryCrduApi.Countries.Service.Interfaces
{
    public interface ICountryCommandService
    {
        Task<Country> CreateCountry(CreateCountryRequest request);
        Task<Country> UpdateCountry(UpdateCountryRequest request);
        Task<Country> DeleteCountry(int id);
    }
}
