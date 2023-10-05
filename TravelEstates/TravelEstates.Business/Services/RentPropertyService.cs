using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelEstates.Business.Abstraction.Factories;
using TravelEstates.Business.Abstraction.Services;
using TravelEstates.Business.Models.DTOs.RentPropertyDTOs;
using TravelEstates.Business.Models.Results.Base;
using TravelEstates.Business.Models.Utilities;
using TravelEstates.Data.Abstraction.Repositories;
using TravelEstates.Data.Models.Entities.Base;

namespace TravelEstates.Business.Services
{
    public class RentPropertyService : IRentPropertyService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IRentPropertyRepository _rentPropertyRepository;
        private readonly IPropertyTypeRepository _propertyTypeRepository;

        public RentPropertyService(
            IMapper mapper,
            IResultFactory resultFactory,
            IRentPropertyRepository rentPropertyRepository,
            IPropertyTypeRepository propertyTypeRepository)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _rentPropertyRepository = rentPropertyRepository;
            _propertyTypeRepository = propertyTypeRepository;
        }

        public async Task<IResult<ICollection<RentPropertyResultDTO>>> GetAllAsync()
        {
            var rentProperties = await _rentPropertyRepository.GetAllAsync(rp => true);

            if (!rentProperties.Any())
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<ICollection<RentPropertyResultDTO>>(RentPropertyDTOMessages.PropertiesNotFound);
                return notFoundResult;
            }

            // Retrieve PropertyTypes for all RentProperties
            var propertyTypeIds = rentProperties.Select(rp => rp.PropertyTypeId).ToList();
            var propertyTypes = await _propertyTypeRepository.GetAllAsync(pt => propertyTypeIds.Contains(pt.Id));

            // Map RentProperties to RentPropertyResultDTO and populate PropertyTypeName
            var rentPropertyResultDTOs = rentProperties.Select(rp =>
            {
                var resultDTO = _mapper.Map<RentPropertyResultDTO>(rp);
                resultDTO.PropertyTypeName = propertyTypes.FirstOrDefault(pt => pt.Id == rp.PropertyTypeId)?.Name;
                return resultDTO;
            }).ToList();

            var okResult = _resultFactory.GetOkResult((ICollection<RentPropertyResultDTO>)rentPropertyResultDTOs);

            return okResult;
        }

        public async Task<IResult<RentPropertyResultDTO>> GetByIdAsync(string id)
        {
            var rentProperty = await _rentPropertyRepository.FindEntityAsync(rp => rp.Id == id);

            if (rentProperty == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<RentPropertyResultDTO>(RentPropertyDTOMessages.PropertiesNotFound);
                return notFoundResult;
            }

            var propertyType = await _propertyTypeRepository.FindEntityAsync(pt => pt.Id == rentProperty.PropertyTypeId);

            var rentPropertyResultDTO = _mapper.Map<RentPropertyResultDTO>(rentProperty);
            rentPropertyResultDTO.PropertyTypeName = propertyType?.Name;

            var okResult = _resultFactory.GetOkResult(rentPropertyResultDTO);

            return okResult;
        }


        public async Task<IResult<RentPropertyResultDTO>> AddAsync(RentPropertyCreateDTO rentPropertyCreateDTO)
        {
            var rentPropertyEntity = _mapper.Map<RentProperty>(rentPropertyCreateDTO);

            var propertyType = await _propertyTypeRepository.FindEntityAsync(pt => pt.Id == rentPropertyEntity.PropertyTypeId);

            if (propertyType != null)
            {
                var createdResultDTO = _mapper.Map<RentPropertyResultDTO>(rentPropertyEntity);
                createdResultDTO.PropertyTypeName = propertyType.Name;

                await _rentPropertyRepository.AddAsync(rentPropertyEntity);

                var createdResult = _resultFactory.GetCreatedResult(createdResultDTO);

                return createdResult;
            }
            else
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<RentPropertyResultDTO>(RentPropertyDTOMessages.InvalidPropertyTypeId);
                return badRequestResult;
            }
        }

        public async Task<IResult<RentPropertyResultDTO>> UpdateAsync(string id, RentPropertyUpdateDTO rentPropertyUpdateDTO)
        {
            var existingRentProperty = await _rentPropertyRepository.FindEntityAsync(rp => rp.Id == id);

            if (existingRentProperty == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<RentPropertyResultDTO>(RentPropertyDTOMessages.PropertyNotFound);
                return notFoundResult;
            }

            // Keep a reference to the existing PropertyTypeId
            var existingPropertyTypeId = existingRentProperty.PropertyTypeId;

            _mapper.Map(rentPropertyUpdateDTO, existingRentProperty);

            // Check if PropertyTypeId has changed
            if (existingRentProperty.PropertyTypeId != existingPropertyTypeId)
            {
                var propertyType = await _propertyTypeRepository.FindEntityAsync(pt => pt.Id == existingRentProperty.PropertyTypeId);

                if (propertyType != null)
                {
                    existingRentProperty.PropertyType = propertyType; // Update the navigation property
                    existingRentProperty.PropertyTypeId = propertyType.Id; // Update the PropertyTypeId

                    // Include PropertyTypeName in the RentPropertyResultDTO
                    var updatedResultDTO = _mapper.Map<RentPropertyResultDTO>(existingRentProperty);
                    updatedResultDTO.PropertyTypeName = propertyType.Name;

                    await _rentPropertyRepository.UpdateAsync(existingRentProperty);

                    var updatedResult = _resultFactory.GetOkResult(updatedResultDTO);

                    return updatedResult;
                }
                else
                {
                    var badRequestResult = _resultFactory.GetBadRequestResult<RentPropertyResultDTO>(RentPropertyDTOMessages.InvalidPropertyTypeId);
                    return badRequestResult;
                }
            }
            else
            {
                await _rentPropertyRepository.UpdateAsync(existingRentProperty);

                var updatedResultDTO = _mapper.Map<RentPropertyResultDTO>(existingRentProperty);
                var updatedResult = _resultFactory.GetOkResult(updatedResultDTO);

                return updatedResult;
            }
        }

        public async Task<IResult<RentPropertyDeleteDTO>> DeleteAsync(string id)
        {
            var existingRentProperty = await _rentPropertyRepository.FindEntityAsync(rp => rp.Id == id);

            if (existingRentProperty == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<RentPropertyDeleteDTO>(BookingDTOMessages.BookingNotFound);

                return notFoundResult;
            }

            await _rentPropertyRepository.DeleteAsync(existingRentProperty);

            var okResult = _resultFactory.GetOkResult<RentPropertyDeleteDTO>();

            return okResult;
        }
    }
}
