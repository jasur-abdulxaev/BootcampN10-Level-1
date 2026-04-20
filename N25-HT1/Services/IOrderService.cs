public interface IOrderService
{
    // Bitta mahsulot xarid qilish (id bo'yicha)
    bool Order(int id, DebitCard card);

    // FilterModel bo'yicha topilgan barcha mahsulotlarni xarid qilish
    bool Order(ProductFilterModel filterModel, DebitCard card);
}