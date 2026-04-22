var source = new List<int> { 5, 3, 1, 4, 2 };

// Defferent
IEnumerable<int> defferent = source.Where(x => x > 2);
// retsep, xotirada faqat tavsifi saqlanadi
// bajarilishi foreach/tolist da

// Immediate
List<int> immediate = source.Where(x => x > 3).ToList();
// Xotirada xaqiqiy qiymatlar saqlanadi

// Mixed
IEnumerable<int> mixed = source
    .OrderBy(x => x)                //xotirada: [1,2,3,4,5] bufferga
    .Where(x => x > 2);             //xotirada: faqat tavsif, buffer ustida

foreach (var n in mixed)
    Console.WriteLine(n + " ");         // 3,4,5
