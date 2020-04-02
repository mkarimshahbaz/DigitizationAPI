using DigitizationAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizationAPI.Services
{
    public interface IIndividualRepository
    {
        bool individualExists(string Name, string FName, string GName, int DoBYear);

        IEnumerable<Individual> searchIndividuals(string Name, string FName, string GName, int DoBYear);   

        Individual getIndividual(int ID);

        IEnumerable<Individual> getIndividuals();


        IEnumerable<Individual> getIndividuals(IEnumerable<int> individualIds);

    }
}
