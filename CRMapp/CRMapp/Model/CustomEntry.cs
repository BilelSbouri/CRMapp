using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CRMapp.Model
{
    public class CustomEntry : Entry
    {
        public static implicit operator CustomEntry(string v)
        {
            throw new NotImplementedException();
        }
    }
}
