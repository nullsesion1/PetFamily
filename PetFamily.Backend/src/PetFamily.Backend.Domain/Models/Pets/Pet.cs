using CSharpFunctionalExtensions;
using PetFamily.Backend.Domain.Models.Pets;
using PetFamily.Backend.Domain.Models.ValueObject;

namespace PetFamily.Backend.Domain.Models.Pets
{
	public class Pet
	{
		//id
		public Guid PetId { get; private set; }
		//Кличка
		public string Name { get; private set; } = default!;
		//Вид(например - собака, кошка)
		public SpeciesEnum Species { get; private set; }
		//Описание
		public string Description { get; private set; }
		//Порода
		public string Breed { get; private set; } = default!;
		//Окрас
		public string Color { get; private set; }
		//Информация о здоровье питомца
		public string HealthInfo { get; private set; }
		//Адрес, где находится питомец
		public string Address { get; private set; }
		//Вес подразумевается что вес всегда будет в граммах
		public int Weight { get; private set; }
		//Рост подразумевается что (для собак/кошек рост в холке, для змей длинна) всегда будет в миллиметрах
		public int Size { get; private set; }
		//Номер телефона для связи с владельцем
		public string PhoneNumber { get; private set; }
		//Кастрирован или нет (способен приносить потомство для самцов кастрация)
		public bool IsReproductive { get; private set; }
		//Дата рождения
		public DateOnly BirthOfDate { get; private set; }
		//Вакцинирован или нет
		public bool IsVaccinated { get; private set; }
		//Статус помощи - Нуждается в помощи/Ищет дом/Нашел дом
		public PetHelpStatusEnum HelpStatus { get; private set; }
		public List<RequisitePaymentInfo> Requisites { get; private set; }
		//Дата создания
		public DateTime Created { get; private set; }

		private Pet(
			Guid petId
			, string name
			, SpeciesEnum species
			, string description
			, string breed
			, string color
			, string healthInfo
			, string address
			, int weight
			, int size
			, string phoneNumber
			, bool isReproductive
			, DateOnly birthOfDate
			, bool isVaccinated
			, PetHelpStatusEnum helpStatus
			, List<RequisitePaymentInfo> requisites
			, DateTime created
			)
		{
			PetId = petId;
			Name = name;
			Species = species;
			Description = description;
			Breed = breed;
			Color = color;
			HealthInfo = healthInfo;
			Address = address;
			Weight = weight;
			Size = size;
			PhoneNumber = phoneNumber;
			IsReproductive = isReproductive;
			BirthOfDate = birthOfDate;
			IsVaccinated = isVaccinated;
			HelpStatus = helpStatus;
			Requisites = requisites;
			Created = created;
		}

		public static Result<Pet> Create(
			Guid? petId
			, string name
			, SpeciesEnum species
			, string description
			, string breed
			, string color
			, string healthInfo
			, string address
			, int weight
			, int size
			, string phoneNumber
			, bool isReproductive
			, DateOnly birthOfDate
			, bool isVaccinated
			, PetHelpStatusEnum helpStatus
			, List<RequisitePaymentInfo> requisites
			, DateTime created)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return Result.Failure<Pet>("name must not be empty");
			}

			if (string.IsNullOrWhiteSpace(breed))
			{
				return Result.Failure<Pet>("breed must not be empty");
			}

			return Result.Success(new Pet(
				petId ?? Guid.NewGuid()
				, name
				, species
				, description
				, breed
				, color
				, healthInfo
				, address
				, weight
				, size
				, phoneNumber
				, isReproductive
				, birthOfDate
				, isVaccinated
				, helpStatus
				, requisites
				, created));
		}
	}
}