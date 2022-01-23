using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Helper
{
    public sealed class CodePagesEncodingProvider : System.Text.EncodingProvider
    {
        public override Encoding GetEncoding(int codepage)
        {
            throw new NotImplementedException();
        }

        public override Encoding GetEncoding(string name)
        {
            throw new NotImplementedException();
        }
    }
}
