using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binsearch
{
    public class stack
    {
        List<object> st = new List<object>( );
        public void push( object data ) => st.Add( data );

        public object pop()
        {
            var elem = st.ElementAt( st.Count );
            st.Remove( elem );
            return elem;
        }

        public object peek() => st.Last( );

        public List<object> getStack()
        {
            var copy = new List<object>( st.Count );
            st.ForEach( ( item ) => copy.Add( item ) );
            return copy;
        }

    }

}
