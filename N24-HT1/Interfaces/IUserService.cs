public interface IUserService
{
    // Barcha (o'chirilmagan) userlarni pagination bilan qaytaradi
    List<User> Get(int pageSize, int pageToken);

    // Kalit so'z bo'yicha (firstName yoki lastName yoki email) qidiradi
    List<User> Search(string searchKeyword, int pageSize, int pageToken);

    // UserFilterModel asosida filter qiladi
    List<User> Filter(UserFilterModel userFilterModel);

    // Yangi user qo'shadi; email takrorlanmas bo'lishi shart
    User Add(string firstName, string lastName, string emailAddress);

    // Mavjud userni yangilaydi
    User Update(User user);

    // Soft delete — IsDeleted = true
    void Delete(Guid id);
}