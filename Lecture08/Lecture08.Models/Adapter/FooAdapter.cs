using System;

namespace Lecture08.Models.Adapter
{
    public class FooAdapter : IFooService
    {
        public bool Update(Foo foo)
        {
            try
            {
                FoolishService.Modify(foo);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
