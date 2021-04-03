using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace DigitArc.Core.Dal
{
    public interface IAuthModel
    {
        #region Members
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }

        Claim[] Claims { get; set; }
        #endregion
    }
}
