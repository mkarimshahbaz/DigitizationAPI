using DigitizationAPI.DbContexts;
using DigitizationAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitizationAPI.Services
{
    public class IndividualRepository : IIndividualRepository
    {
        private readonly IndividualsDbContext _individualsDbContext;

        public IndividualRepository(IndividualsDbContext context)
        {
            _individualsDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Individual> getIndividuals()
        {
            return _individualsDbContext.Individuals.ToList();
        }


        public Individual getIndividual(int ID)
        {
            return _individualsDbContext.Individuals.Where(i => i.ID == ID).FirstOrDefault();
        }

        public IEnumerable<Individual> getIndividuals(IEnumerable<int> individualIds)
        {
            throw new NotImplementedException();
        }

        public bool individualExists(string Name, string FName, string GName, int DoBYear)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Individual> searchIndividuals(string Name, string FName, string GName, int DoBYear)
        {
            Name = Name.Trim();
            FName = FName.Trim();
            GName = GName.Trim();

            var individualsFromQuery = _individualsDbContext.Individuals.Where(i => i.Name == Name 
                                        && i.FName == FName && i.GName == GName && i.DoBYear == DoBYear)
                                        .ToList();

            if (!individualsFromQuery.Any())
            {
                Name = Regex.Replace(Name, @"\s", "");
                FName = Regex.Replace(FName, @"\s", "");
                GName = Regex.Replace(GName, @"\s", "");

                individualsFromQuery = _individualsDbContext.Individuals
                                        .FromSqlRaw("SELECT * FROM NSIA.Individuals WHERE REPLACE(Name, ' ', '') = {0}" +
                                        " AND REPLACE(FName, ' ', '') = {1} AND REPLACE(GName, ' ', '') = {2}" +
                                        " AND DoBYear = {3}", Name, FName, GName, DoBYear)
                                        .ToList();
            }

            return individualsFromQuery;
        }
    }
}
