using System;
using System.Collections.Generic;

namespace simbat
{
	/// <summary>
	/// I mapper. You mapper.
	/// </summary>
	public interface IMapper<T>
	{
		List<T> findAll();
		T       find(UInt32 id);
		int     update(T t);
		int     delete(T t);
		void    insert(T t);
	}
}

