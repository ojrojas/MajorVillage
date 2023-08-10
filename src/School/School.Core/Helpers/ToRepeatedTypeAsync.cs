namespace School.Core.Helpers;

public static class RepeatedTypeAsync
{
	public static RepeatedField<TM> ToRepeatedTypeAsync<T2, TM>(this IEnumerable<T2> areas, IMapper mapper)
	{
		ArgumentNullException.ThrowIfNull(mapper);
		var repeatedFields = new RepeatedField<TM>();
		repeatedFields.AddRange(areas.Select(x => mapper.Map<TM>(x)));
		return repeatedFields;
	}
}

