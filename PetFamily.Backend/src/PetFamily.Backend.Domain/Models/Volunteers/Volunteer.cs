using PetFamily.Backend.Domain.Models.Pets;
using PetFamily.Backend.Domain.Models.ValueObject;

namespace PetFamily.Backend.Domain.Models.Volunteers
{
	public class Volunteer
	{
		private readonly List<RequisitePaymentInfo> _requisitesPaymentsInfo = default!;
		private readonly List<Pet> _pets = default!;
		private readonly List<SocialNetwork> _socialNetworks = default!;

		public Guid Id { get; private set; }
		//ФИО
		public string FullName { get; private set; } = default!;
		//Общее описание
		public string Description { get; private set; } = default!;
		//Опыт в годах
		public int Experience { get; private set; }
		//Количество домашних животных, которые смогли найти дом (это должен быть метод)
		public int PetsFoundHomeCount => _pets.Count(x => (x.HelpStatus & PetHelpStatusEnum.IsHomeLess) == 0);
		//Количество домашних животных, которые ищут дом в данный момент времени (это должен быть метод)
		public int PetsSearchingHomeCount => _pets.Count(x => x.HelpStatus.HasFlag(PetHelpStatusEnum.IsHomeLess));
		//Количество животных, которые сейчас находятся на лечении (это должен быть метод)
		public int PetTreatmentCount => _pets.Count(x => x.HelpStatus.HasFlag(PetHelpStatusEnum.IsNeedHelp));
		//Номер телефона
		public string PhoneNumber { get; private set; }
		//Реквизиты для помощи, поэтому нужно сделать отдельный класс для реквизита requisite
		public IReadOnlyList<RequisitePaymentInfo> RequisitesPaymentInfo => _requisitesPaymentsInfo;
		//Список домашних животных, которыми владеет волонтёр
		public IReadOnlyList<Pet> Pets => _pets;
		//Социальные сети (список соц. сетей, у каждой социальной сети должна быть ссылка и название), поэтому нужно сделать отдельный класс для социальной сети.
		public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

		private Volunteer(Guid id
			, string fullName
			, string description
			, int experience
			, string phoneNumber
			, List<SocialNetwork> socialNetworks
			, List<RequisitePaymentInfo> requisites
			, List<Pet> pets
			)
		{
			Id = id;
			FullName = fullName;
			Description = description;
			Experience = experience;
			PhoneNumber = phoneNumber;
			AddSocialNetworks(socialNetworks);
			AddRequisites(requisites);
			AddPets(pets);
		}

		public void AddRequisites(List<RequisitePaymentInfo> requisites) => _requisitesPaymentsInfo.AddRange(requisites);
		public void AddPets(List<Pet> pets) => _pets.AddRange(pets);
		public void AddSocialNetworks(List<SocialNetwork> socialNetworks) => _socialNetworks.AddRange(socialNetworks);
	}
}
