using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace PetFamily.Backend.Domain.Models.ValueObject
{
	public record SocialNetwork
	{
		public string Name { get; } = default!;
		public string Link { get; } = default!;

		private SocialNetwork(string name, string link)
		{
			Name = name;
			Link = link;
		}

		public Result<SocialNetwork> Create(string name, string link)
		{
			if (string.IsNullOrWhiteSpace(name))
				return Result.Failure<SocialNetwork>("Social Network A social network must have a name");

			if (!string.IsNullOrWhiteSpace(link))
				return Result.Failure<SocialNetwork>("Social Network A social network must have a link");

			return Result.Success(new SocialNetwork(name, link));
		}
	}
}
