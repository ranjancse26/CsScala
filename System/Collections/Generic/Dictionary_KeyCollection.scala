package System.Collections.Generic

import System.NotImplementedException

class Dictionary_KeyCollection[T](i:java.util.Set[T]) extends Traversable[T] 
{

  def Count:Int = 
  {
    return i.size();
  }
  def foreach[U](fn:T=>U)
  {
    val it = i.iterator;
	while (it.hasNext()) 
	{
	   fn(it.next());
	}
  }
}