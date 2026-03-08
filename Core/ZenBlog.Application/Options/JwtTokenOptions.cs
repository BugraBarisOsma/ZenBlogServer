using System;
using System.Collections.Generic;
using System.Text;

namespace ZenBlog.Application.Options
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; } //  Oluşturulan token'ın kim tarafından oluşturulduğunu belirtir. Sunucu tarafi 
        public string Audience { get; set; } // Token'ın hangi kullanıcılar veya sistemler tarafından kullanılabileceğini belirtir. Genellikle uygulamanın kendisi veya belirli bir kullanıcı grubu olabilir.
        public string Key { get; set; } // Token'ın imzalanması için kullanılan gizli anahtardır. Bu anahtar, token'ın doğruluğunu sağlamak ve yetkisiz erişimi önlemek için kullanılır. Genellikle uzun ve karmaşık bir dize olarak tanımlanır.
        public string ExpireInMinutes { get; set; } // Token'ın geçerlilik süresini dakika cinsinden belirtir. Bu süre dolduğunda token geçersiz hale gelir ve kullanıcıların yeniden kimlik doğrulaması yapması gerekebilir.
    }
}
