using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binsearch
{
    public class queue
    {
        List<object> que = new List<object>( );

        public void enqueue( object item ) => que.Add( item );

        public object dequeue( )
        {
            var item = que.First( );
            que.RemoveAt( 0 );
            return item;
        }

        public int size() => que.Count;

        public object peek() => que.First( );

    }
}
