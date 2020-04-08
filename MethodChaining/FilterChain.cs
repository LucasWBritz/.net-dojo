using System.Collections.Generic;
using System.Linq;

namespace MethodChaining 
{
    public class FilterChain {

        private List<int> _numbers;
        public FilterChain(List<int> numbers)
        {
            _numbers = numbers;
        }

        public List<int> GetNumbers()
        {
            return _numbers;
        }

        public FilterChain RemoveEven()
        {
            _numbers = _numbers.Where(x => x % 2 != 0).ToList();
            return this;
        }

        public FilterChain RemoveDuplicated()
        {
            _numbers = _numbers.Distinct().ToList();
            return this;
        }

        public FilterChain RemoveValue(int value)
        {
            _numbers.Remove(value);
            return this;
        }
    }
}