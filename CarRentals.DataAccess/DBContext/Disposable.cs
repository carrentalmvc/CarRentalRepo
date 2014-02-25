using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.DataAccess
{
    
   public  class Disposable : IDisposable
    {
       private bool isDisposed;

       ~Disposable()
       { 
          
       }
        public void Dispose()
        {
            Dispose(true);
            //This specifies that CLR does not call the Fanalizer on this instance.
            //This is done to prevent the fanalizer from releasing unmanaged resourcesthat have already been freed by IDisposable.Dispose implemnettaion
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;            
        }

       //Let the derived class override this 
        protected virtual void DisposeCore()
        {
            
        }
    }
}
