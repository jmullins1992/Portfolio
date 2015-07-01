using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using Models;
using Models.Interfaces;

namespace FlooringMastery.BLL
{
    public class TaxOperations
    {
        private readonly IStateTaxInfoRepository _myStateTaxInfoRepository;

        public TaxOperations(IStateTaxInfoRepository aStateTaxInfoRepository)
        {
            _myStateTaxInfoRepository = aStateTaxInfoRepository;
        }

        public Response<decimal> GetRate(string stateAbbreviation)
        {
            List<StateTaxInfo> allTaxes;
            var response = new Response<decimal>();

            try
            {
                allTaxes = _myStateTaxInfoRepository.ListAll();
                response.Data = allTaxes.First(s => s.StateAbbreviation == stateAbbreviation).TaxRate;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
           
            return response;
        }        

        public Response<bool> IsValidState(string stateAbbreviation)
        {
            List<StateTaxInfo> allTaxes;
            var response = new Response<bool>();

            try
            {
                allTaxes = _myStateTaxInfoRepository.ListAll();
                response.Data = allTaxes.Any(s => s.StateAbbreviation == stateAbbreviation);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                try
                {
                    var repo = new LogRepository();
                    repo.WriteLog(ex.Message);
                }
                catch
                {
                    response.Message += "\nCould not write to log file.";
                }
            }

            return response;
        }
    }
}
