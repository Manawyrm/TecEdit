using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
    public class GetPCDescriptionResult : BaseEvent<string>
    {
        private string mResult;

        public GetPCDescriptionResult(string httpPostResult, string errorMessage, string postRequest)
            : base(errorMessage, postRequest)
        {
            DecodeResult(httpPostResult);
        }

        public override string Name
        {
            get { return RequestType.GetAllUserPC.ToString(); }
        }

        public override string Result
        {
            get { return mResult; }
        }

        private void DecodeResult(string httpPostResult)
        {
            //meep! Hier mal code. :P
        }
    }
}
