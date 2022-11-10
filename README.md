# Gumec_AI

Gumec Tower Defence oyunlarından esinlenerek yapılmış bir oyundur. Oyun içerisinde kullanılan assetler gamedev.tv tarafından sağlanmıştır. Oyunda giriş sahnesi bulunuyor, eklemek istersek farklı sahnelerde eklenilebilir.

![Gumec_AI](https://user-images.githubusercontent.com/91124447/201181898-aa2237c0-b23a-4bd9-a196-7888b6017f22.png)

Oyun içerisinde belirli bir yol bulunmamaktadır. Oyun içerisinde yapay zeka kullanılmıştır. Yapay zeka olarak BFS(Breath-First Search ) methodu kullanılarak düşmanların kendilerine göre en kısa yolu bulması sağlanmıştır. Oyun içerisinde düşman arabalarının bir başlangıç- bir tane bitiş noktası bulunmaktadır.

![gumec_aı2](https://user-images.githubusercontent.com/91124447/201181989-06cf9d6b-bae2-4449-9924-7b8ffcefac81.png)

Her öldürülen düşmandan para kazanılırken, her düşmanın bitiş noktasına gelmesiyle sahip olunan para miktarında azalmak olmaktadır. Oyun içerisinde savunma için kullanılan objeler ise kullanılmaya başlanırsa yine para miktarı azalacaktır. Oyunum grid sistemi ile tasarlanmıştır. Oyun içerisinde tıkladığını noktaya savunma yapmak üzere "target" diye isimlendirdiğim objeler konulmaktadır, ve düşman arabaları üzerinden geçememektedir ve kendilerine göre en yakın yolu tekrar hesaplamaya başlayacaklardır.

![gumec_aı3](https://user-images.githubusercontent.com/91124447/201182013-d25443ed-af87-43fe-ad51-76d66926cc26.png)
