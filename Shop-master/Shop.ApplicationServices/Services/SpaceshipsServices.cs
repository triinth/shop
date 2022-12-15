﻿using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain.Spaceship;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly ShopContext _context;
        public SpaceshipsServices
            (
            ShopContext context
            )
        {
            _context = context;
        }

        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Type = dto.Type,
                Crew = dto.Crew,
                Passengers = dto.Passengers,
                CargoWeight = dto.CargoWeight,
                FullTripsCount = dto.FullTripsCount,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                EnginePower = dto.EnginePower,
                MaidenLaunch = dto.MaidenLaunch,
                BuiltDate = dto.BuiltDate,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            await _context.Spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Id = dto.Id,
                Name = dto.Name,
                Type = dto.Type,
                Crew = dto.Crew,
                Passengers = dto.Passengers,
                CargoWeight = dto.CargoWeight,
                FullTripsCount = dto.FullTripsCount,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                EnginePower = dto.EnginePower,
                MaidenLaunch = dto.MaidenLaunch,
                BuiltDate = dto.BuiltDate,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();
            return domain;

            
        }
        public async Task<Spaceship> GetUpdate(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }
    }
}
