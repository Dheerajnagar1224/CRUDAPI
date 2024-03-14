using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public class DbHelper
{
    private readonly EF_Datacontext _dbContext;

    public DbHelper(EF_Datacontext dbContext)
    {
        _dbContext = dbContext;
    }

    // Create
    public void CreateEntity(EntityDto entityDto)
    {
        var entity = MapDtoToEntity(entityDto);
       
        if (entity != null) {
            _dbContext.Entities.Add(entity);
            _dbContext.SaveChanges();
        }
        else
        {
            throw new Exception("Error Occured");
        }
       
    }




    // Read
    public IEnumerable<EntityDto> GetEntities(string? addressCountry, string? gender, DateTime? startdate, DateTime? enddate, string? searchQuery,
         int skip, int pageSize, string sortBy, string sortDirection)
    {

        try
        {


            IQueryable<Entity> query = _dbContext.Entities.Include(e => e.Addresses).Include(e => e.Dates).Include(e => e.Names);




            // Filtering
            if (!string.IsNullOrEmpty(addressCountry))
            {
                query = query.Where(e => e.Addresses.Any(a => a.Country == addressCountry));
            }

            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(e => e.Gender == gender);
            }

            if (startdate != null && enddate != null)
            {
                query = query.Where(e => e.Dates.Any(d => d.DateValue >= startdate && d.DateValue <= enddate));
            }




            // Search
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(e =>
                    e.Addresses.Any(a => a.Country.Contains(searchQuery) || a.AddressLine.Contains(searchQuery)) ||
                    e.Names.Any(n => n.FirstName.Contains(searchQuery) || n.MiddleName.Contains(searchQuery) || n.Surname.Contains(searchQuery))
                );
            }



            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "deceased":
                        query = sortDirection.ToLower() == "asc" ? query.OrderBy(e => e.Deceased) : query.OrderByDescending(e => e.Deceased);
                        break;
                    case "gender":
                        query = sortDirection.ToLower() == "asc" ? query.OrderBy(e => e.Gender) : query.OrderByDescending(e => e.Gender);
                        break;
                    default:

                        query = sortDirection.ToLower() == "asc" ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id);
                        break;


                }

            }



            query = query.Skip(skip).Take(pageSize);
            var entities = query.ToList();
            return entities.Select(MapEntityToDto);
        }
        catch(Exception ex) {
         
                throw new Exception("Error Occured");
            
        }
    }


    // Read Getbyid
    public EntityDto Getbyid(string id)
    {

        var entity = _dbContext.Entities.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            return MapEntityToDto(entity);
        }
        else if (entity == null)
        {
            throw new InvalidDataException("Id Doesnt Exist");
        }
        else
        {
            throw new Exception("Error Occured");
        }

    }





    // Update
    public void UpdateEntity(string id, EntityDto entityDto)
    {
        var entity = _dbContext.Entities.FirstOrDefault(e => e.Id == id);
        if (entity == null)
        {
            throw new InvalidDataException("Id Doesnt Exist");
        }
        if (entityDto.Address != null)
        {
            entity.Addresses?.Clear(); // Remove existing addresses
            entity.Addresses = entityDto.Address?.Select(MapAddressDtoToEntity).ToList();// Add new address
        }
        if (entityDto.Dates != null)
        {
            entity.Dates.Clear(); // Remove existing addresses
            entity.Dates = entityDto.Dates?.Select(MapDateDtoToEntity).ToList(); // Add new address
        }
        if (entityDto.Names != null)
        {
            entity.Names.Clear(); // Remove existing addresses
            entity.Names = entityDto.Names?.Select(MapNameDtoToEntity).ToList(); // Add new address
        }
        if(entity != null)
        {
            // Update properties
            entity.Deceased = entityDto.Deceased;
            entity.Gender = entityDto.Gender;
        }
        else
        {
            throw new Exception("Error Occured");
        }

   

        _dbContext.SaveChanges();

    }





    // Delete
    public void DeleteEntity(string id)
    {
        var entity = _dbContext.Entities.FirstOrDefault(e => e.Id == id);
        if (entity == null)
        {
            throw new InvalidDataException("Id Doesnt Exist");
        }
        else if (entity != null)
        {
            _dbContext.Entities.Remove(entity);
            _dbContext.SaveChanges();
        }
        else
        {
           throw new Exception("Error Occured");
        }
    }


  

    





    // Helper method to map DTO to entity
    private Entity MapDtoToEntity(EntityDto entityDto)
    {
        // Map properties from DTO to entity
     
         var entity = new Entity
         {
             Id = entityDto.Id,
             Deceased = entityDto.Deceased,
             Gender = entityDto.Gender,
             Addresses = entityDto.Address?.Select(MapAddressDtoToEntity).ToList(),
             Dates = entityDto.Dates?.Select(MapDateDtoToEntity).ToList(),
             Names = entityDto.Names?.Select(MapNameDtoToEntity).ToList(),
         };

         return entity;
    }

    // Helper method to map entity to DTO
    private EntityDto MapEntityToDto(Entity entity)
    {
        var entityDto = new EntityDto
        {
            Id = entity.Id,
            Deceased = entity.Deceased,
            Gender = entity.Gender,
            Address = entity.Addresses?.Select(MapAddressEntityToDto).ToList(),
            Dates = entity.Dates?.Select(MapDateEntityToDto).ToList(),
            Names = entity.Names?.Select(MapNameEntityToDto).ToList()
        };

        return entityDto;
    }






    // Helper method to map Address entity to AddressDto
    private AddressDto MapAddressEntityToDto(Address address)
    {
        return new AddressDto
        {
            AddressLine = address?.AddressLine,
            City = address?.City,
            Country = address?.Country
        };
    }

    // Helper method to map Date entity to DateDto
    private DateDto MapDateEntityToDto(Date date)
    {
        return new DateDto
        {
            DateType = date?.DateType,
            DateValue = date?.DateValue
        };
    }

    // Helper method to map Name entity to NameDto
    private NameDto MapNameEntityToDto(Name name)
    {
        return new NameDto
        {
            FirstName = name?.FirstName,
            MiddleName = name?.MiddleName,
            Surname = name?.Surname
        };
    }







    // Helper method to map Address entity to AddressDto
    private Address MapAddressDtoToEntity(AddressDto address)
    {
        return new Address
        {
            AddressLine = address?.AddressLine,
            City = address?.City,
            Country = address?.Country
        };
    }

    // Helper method to map Date entity to DateDto
    private Date MapDateDtoToEntity(DateDto date)
    {
        return new Date
        {
            DateType = date?.DateType,
            DateValue = date?.DateValue
        };
    }

    // Helper method to map Name entity to NameDto
    private Name MapNameDtoToEntity(NameDto name)
    {
        return new Name
        {
            FirstName = name?.FirstName,
            MiddleName = name?.MiddleName,
            Surname = name?.Surname
        };
    }

}