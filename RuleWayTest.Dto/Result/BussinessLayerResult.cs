using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuleWayTest.Dto.Enum;

namespace RuleWayTest.Dto.Result
{
    public class BussinessLayerResult<T>
    {
        public T Result { get; set; }
        public List<ErrorDto> Errors { get; set; }
        public EResultStatus Status
        {
            get
            {
                if (Errors == null)
                {
                    return EResultStatus.Success;
                }
                if (Errors.Count > 0)
                {
                    return EResultStatus.Error;
                }
                return EResultStatus.Success;

            }
            
        }

        public BussinessLayerResult()
        {
            Errors = new List<ErrorDto>();
        }

        public void AddError(EMessageCode code,string message)
        {
            Errors.Add(new ErrorDto { Code = code, Message = message });
        }


    }
}
