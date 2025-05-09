// Copyright © https://myCSharp.de - all rights reserved

using Xunit;

namespace MyCSharp.HttpUserAgentParser.UnitTests;

public class HttpUserAgentParserTests
{
    [Theory]
    // IE
    [InlineData("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; WOW64; Trident/4.0;)", "Internet Explorer", "7.0", "Windows Vista", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0)", "Internet Explorer", "8.0", "Windows XP", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)", "Internet Explorer", "8.0", "Windows 7", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/4.0 (compatible; MSIE 9.0; Windows NT 6.0)", "Internet Explorer", "9.0", "Windows Vista", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/4.0 (compatible; MSIE 9.0; Windows NT 6.1)", "Internet Explorer", "9.0", "Windows 7", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)", "Internet Explorer", "10.0", "Windows 7", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2)", "Internet Explorer", "10.0", "Windows 8", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Windows NT 6.1; Trident/7.0; rv:11.0) like Gecko", "Internet Explorer", "11.0", "Windows 7", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Windows NT 6.2; Trident/7.0; rv:11.0) like Gecko", "Internet Explorer", "11.0", "Windows 8", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko", "Internet Explorer", "11.0", "Windows 8.1", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Windows NT 10.0; Trident/7.0; rv:11.0) like Gecko", "Internet Explorer", "11.0", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    // Chrome
    [InlineData("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36", "Chrome", "90.0.4430.212", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36", "Chrome", "90.0.4430.212", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36", "Chrome", "90.0.4430.212", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Macintosh; Intel Mac OS X 11_3_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36", "Chrome", "90.0.4430.212", "Mac OS X", HttpUserAgentPlatformType.MacOS, null)]
    [InlineData("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36", "Chrome", "90.0.4430.212", "Linux", HttpUserAgentPlatformType.Linux, null)]
    [InlineData("Mozilla/5.0 (iPhone; CPU iPhone OS 14_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/90.0.4430.78 Mobile/15E148 Safari/604.1", "Chrome", "90.0.4430.78", "iOS", HttpUserAgentPlatformType.IOS, "Apple iPhone")]
    [InlineData("Mozilla/5.0 (iPad; CPU OS 14_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/90.0.4430.78 Mobile/15E148 Safari/604.1", "Chrome", "90.0.4430.78", "iOS", HttpUserAgentPlatformType.IOS, "Apple iPad")]
    [InlineData("Mozilla/5.0 (iPod; CPU iPhone OS 14_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/90.0.4430.78 Mobile/15E148 Safari/604.1", "Chrome", "90.0.4430.78", "iOS", HttpUserAgentPlatformType.IOS, "Apple iPod")]
    [InlineData("Mozilla/5.0 (Linux; Android 10) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.210 Mobile Safari/537.36", "Chrome", "90.0.4430.210", "Android", HttpUserAgentPlatformType.Android, "Android")]
    [InlineData("Mozilla/5.0 (Linux; Android 10; SM-A205U) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.210 Mobile Safari/537.36", "Chrome", "90.0.4430.210", "Android", HttpUserAgentPlatformType.Android, "Android")]
    [InlineData("Mozilla/5.0 (Linux; Android 10; LM-Q720) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.210 Mobile Safari/537.36", "Chrome", "90.0.4430.210", "Android", HttpUserAgentPlatformType.Android, "Android")]
    [InlineData("Mozilla/5.0 (X11; CrOS x86_64 15917.71.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.6533.132 Safari/537.36", "Chrome", "127.0.6533.132", "ChromeOS", HttpUserAgentPlatformType.ChromeOS, null)]
    // Safari
    [InlineData("Mozilla/5.0 (Windows; U; Windows NT 10.0; en-US) AppleWebKit/603.1.30 (KHTML, like Gecko) Version/11.0 Safari/605.1.15", "Safari", "11.0", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Macintosh; Intel Mac OS X 11_3_1) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.1 Safari/605.1.15", "Safari", "14.1", "Mac OS X", HttpUserAgentPlatformType.MacOS, null)]
    [InlineData("Mozilla/5.0 (iPhone; CPU iPhone OS 14_5_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0 Mobile/15E148 Safari/604.1", "Safari", "14.0", "iOS", HttpUserAgentPlatformType.IOS, "Apple iPhone")]
    [InlineData("Mozilla/5.0 (iPod touch; CPU iPhone 14_5_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0 Mobile/15E148 Safari/604.1", "Safari", "14.0", "iOS", HttpUserAgentPlatformType.IOS, "Apple iPod")]
    // Edge
    [InlineData("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 Edg/90.0.818.51", "Edge", "90.0.818.51", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Macintosh; Intel Mac OS X 11_3_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 Edg/90.0.818.51", "Edge", "90.0.818.51", "Mac OS X", HttpUserAgentPlatformType.MacOS, null)]
    [InlineData("Mozilla/5.0 (Linux; Android 10; HD1913) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.210 Mobile Safari/537.36 EdgA/46.3.4.5155", "Edge", "46.3.4.5155", "Android", HttpUserAgentPlatformType.Android, "Android")]
    [InlineData("Mozilla/5.0 (iPhone; CPU iPhone OS 14_5_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0 EdgiOS/46.3.13 Mobile/15E148 Safari/605.1.15", "Edge", "46.3.13", "iOS", HttpUserAgentPlatformType.IOS, "Apple iPhone")]
    [InlineData("Mozilla/5.0 (Windows NT 10.0; Win64; x64; Xbox; Xbox One) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 Edge/44.18363.8131", "Edge", "44.18363.8131", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    // Firefox
    [InlineData("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:88.0) Gecko/20100101 Firefox/88.0", "Firefox", "88.0", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Macintosh; Intel Mac OS X 11.3; rv:88.0) Gecko/20100101 Firefox/88.0", "Firefox", "88.0", "Mac OS X", HttpUserAgentPlatformType.MacOS, null)]
    [InlineData("Mozilla/5.0 (X11; Linux i686; rv:88.0) Gecko/20100101 Firefox/88.0", "Firefox", "88.0", "Linux", HttpUserAgentPlatformType.Linux, null)]
    [InlineData("Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:88.0) Gecko/20100101 Firefox/88.0", "Firefox", "88.0", "Linux", HttpUserAgentPlatformType.Linux, null)]
    [InlineData("Mozilla/5.0 (iPhone; CPU iPhone OS 11_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) FxiOS/33.0 Mobile/15E148 Safari/605.1.15", "Firefox", "33.0", "iOS", HttpUserAgentPlatformType.IOS, "Apple iPhone")]
    [InlineData("Mozilla/5.0 (Android 11; Mobile; rv:68.0) Gecko/68.0 Firefox/88.0", "Firefox", "88.0", "Android", HttpUserAgentPlatformType.Android, "Android")]
    // Opera
    [InlineData("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 OPR/76.0.4017.107", "Opera", "76.0.4017.107", "Windows 10", HttpUserAgentPlatformType.Windows, null)]
    [InlineData("Mozilla/5.0 (Macintosh; Intel Mac OS X 11_3_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 OPR/76.0.4017.107", "Opera", "76.0.4017.107", "Mac OS X", HttpUserAgentPlatformType.MacOS, null)]
    [InlineData("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 OPR/76.0.4017.107", "Opera", "76.0.4017.107", "Linux", HttpUserAgentPlatformType.Linux, null)]
    public void BrowserTests(string ua, string name, string version, string platformName, HttpUserAgentPlatformType platformType, string? mobileDeviceType)
    {
        HttpUserAgentInformation uaInfo = HttpUserAgentInformation.Parse(ua);

        Assert.Equal(name, uaInfo.Name);
        Assert.Equal(version, uaInfo.Version);
        Assert.Equal(ua, uaInfo.UserAgent);

        Assert.Equal(HttpUserAgentType.Browser, uaInfo.Type);

        HttpUserAgentPlatformInformation platform = uaInfo.Platform.GetValueOrDefault();
        Assert.Equal(platformType, platform.PlatformType);
        Assert.Equal(platformName, platform.Name);

        Assert.Equal(mobileDeviceType, uaInfo.MobileDeviceType);

        Assert.True(uaInfo.IsBrowser());
        Assert.Equal(mobileDeviceType is not null, uaInfo.IsMobile());
        Assert.False(uaInfo.IsRobot());
    }

    [Theory]
    // Google https://developers.google.com/search/docs/advanced/crawling/overview-google-crawlers
    [InlineData("APIs-Google (+https://developers.google.com/webmasters/APIs-Google.html)", "APIs Google")]
    [InlineData("Mediapartners-Google", "Mediapartners Google")]
    [InlineData("Mozilla/5.0 (Linux; Android 5.0; SM-G920A) AppleWebKit (KHTML, like Gecko) Chrome Mobile Safari (compatible; AdsBot-Google-Mobile; +http://www.google.com/mobile/adsbot.html)", "AdsBot Google Mobile")]
    [InlineData("Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML,like Gecko) Version/9.0 Mobile/13B143 Safari/601.1 (compatible; AdsBot-Google-Mobile; +http://www.google.com/mobile/adsbot.html)", "AdsBot Google Mobile")]
    [InlineData("AdsBot-Google (+http://www.google.com/adsbot.html)", "AdsBot Google")]
    [InlineData("Googlebot-Image/1.0", "Googlebot")]
    [InlineData("Googlebot-News", "Googlebot")]
    [InlineData("Googlebot-Video/1.0", "Googlebot")]
    [InlineData("Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)", "Googlebot")]
    [InlineData("Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; Googlebot/2.1; +http://www.google.com/bot.html) Chrome/1.2.3 Safari/537.36", "Googlebot")]
    [InlineData("Googlebot/2.1 (+http://www.google.com/bot.html)", "Googlebot")]
    [InlineData("Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/1.2.3 Mobile Safari/537.36 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)", "Googlebot")]
    [InlineData("Mediapartners-Google/2.1; +http://www.google.com/bot.html)", "Mediapartners Google")]
    [InlineData("FeedFetcher-Google; (+http://www.google.com/feedfetcher.html)", "FeedFetcher-Google")]
    [InlineData("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36 (compatible; Google-Read-Aloud; +https://developers.google.com/search/docs/advanced/crawling/overview-google-crawlers)", "Google-Read-Aloud")]
    [InlineData("Mozilla/5.0 (Linux; Android 7.0; SM-G930V Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.125 Mobile Safari/537.36 (compatible; Google-Read-Aloud; +https://developers.google.com/search/docs/advanced/crawling/overview-google-crawlers)", "Google-Read-Aloud")]
    [InlineData("Mozilla/5.0 (Linux; Android 8.0; Pixel 2 Build/OPD3.170816.012; DuplexWeb-Google/1.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Mobile Safari/537.36", "DuplexWeb-Google")]
    [InlineData("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.75 Safari/537.36 Google Favicon", "Google Favicon")]
    [InlineData("Mozilla/5.0 (Linux; Android 4.2.1; en-us; Nexus 5 Build/JOP40D) AppleWebKit/535.19 (KHTML, like Gecko; googleweblight) Chrome/38.0.1025.166 Mobile Safari/535.19", "Google Web Light")]
    [InlineData("Mozilla/5.0 (X11; Linux x86_64; Storebot-Google/1.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.88 Safari/537.36", "Storebot-Google")]
    [InlineData("Mozilla/5.0 (Linux; Android 8.0; Pixel 2 Build/OPD3.170816.012; Storebot-Google/1.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Mobile Safari/537.36", "Storebot-Google")]
    // Bing
    [InlineData("Mozilla/5.0 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)", "BingBot")]
    [InlineData("Mozilla/5.0 (iPhone; CPU iPhone OS 7_0 like Mac OS X) AppleWebKit/537.51.1 (KHTML, like Gecko) Version/7.0 Mobile/11A465 Safari/9537.53 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)", "BingBot")]
    [InlineData("Mozilla/5.0 (Windows Phone 8.1; ARM; Trident/7.0; Touch; rv:11.0; IEMobile/11.0; NOKIA; Lumia 530) like Gecko (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)", "BingBot")]
    [InlineData("Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm) Chrome/1.2.3.4 Safari/537.36 Edg/1.2.3.4", "BingBot")]
    [InlineData("Mozilla/5.0 (Linux; Android 6.0.1; Nexus 5X Build/MMB29P) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/1.2.3.4  Mobile Safari/537.36 Edg/1.2.3.4 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)", "BingBot")]
    [InlineData("Mozilla/5.0 (compatible; Baiduspider/2.0; +http://www.baidu.com/search/spider.html)", "Baiduspider")]
    [InlineData("Mozilla/5.0 (compatible; MJ12bot/v1.4.5; http://www.majestic12.co.uk/bot.php?+)", "Majestic")]
    [InlineData("Mozilla/5.0 (compatible; Yahoo! Slurp; http://help.yahoo.com/help/us/ysearch/slurp)", "Slurp")]
    [InlineData("Mozilla/5.0 (compatible; MegaIndex.ru/2.0; +http://megaindex.com/crawler)", "MegaIndex")]
    [InlineData("Mozilla/5.0 (compatible; AhrefsBot/5.2; +http://ahrefs.com/robot/)", "Ahrefs")]
    [InlineData("Mozilla/5.0 (compatible; SemrushBot/7~bl; +http://www.semrush.com/bot.html)", "SEMRush")]
    [InlineData("Mozilla/5.0 (X11; U; Linux Core i7-4980HQ; de; rv:32.0; compatible; JobboerseBot; http://www.jobboerse.com/bot.htm) Gecko/20100101 Firefox/38.0", "Jobboerse")]
    [InlineData("Mozilla/5.0 (compatible; MJ12bot/v1.4.8; http://mj12bot.com/)", "Majestic")]
    [InlineData("Mozilla/5.0 (compatible; SemrushBot/2~bl; +http://www.semrush.com/bot.html)", "SEMRush")]
    [InlineData("Mozilla/5.0 (compatible; YandexBot/3.0; +http://yandex.com/bots)", "YandexBot")]
    [InlineData("Mozilla/5.0 (compatible; YandexImages/3.0; +http://yandex.com/bots)", "YandexImages")]
    [InlineData("Mozilla/5.0 (compatible; Yahoo! Slurp/3.0; http://help.yahoo.com/help/us/ysearch/slurp)", "Slurp")]
    [InlineData("msnbot/1.0 (+http://search.msn.com/msnbot.htm)", "MSNBot")]
    [InlineData("msnbot/2.0b (+http://search.msn.com/msnbot.htm)", "MSNBot")]
    [InlineData("Mozilla/5.0 (compatible; AhrefsBot/5.0; +http://ahrefs.com/robot/)", "Ahrefs")]
    [InlineData("Mozilla/5.0 (compatible; seoscanners.net/1; +spider@seoscanners.net)", "SEO Scanners")]
    [InlineData("Mozilla/5.0 (compatible; SEOkicks-Robot; +http://www.seokicks.de/robot.html)", "SEOkicks")]
    [InlineData("facebookexternalhit/1.1 (+http://www.facebook.com/externalhit_uatext.php)", "Facebook")]
    [InlineData("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534+ (KHTML, like Gecko) BingPreview/1.0b", "Bing Preview")]
    [InlineData("CheckMarkNetwork/1.0 (+http://www.checkmarknetwork.com/spider.html)", "CheckMark")]
    [InlineData("Mozilla/5.0 (compatible; BLEXBot/1.0; +http://webmeup-crawler.com/)", "BLEXBot")]
    [InlineData("Mozilla/5.0 (compatible; Linux x86_64; Mail.RU_Bot/Fast/2.0; +http://go.mail.ru/help/robots)", "Mail.ru")]
    [InlineData("Mozilla/5.0 (compatible; adscanner/)", "AdScanner")]
    [InlineData("Mozilla/5.0 (compatible; SISTRIX Crawler; http://crawler.sistrix.net/)", "Sistrix")]
    [InlineData("Mozilla/5.0 (Linux; Android 7.0;) AppleWebKit/537.36 (KHTML, like Gecko) Mobile Safari/537.36 (compatible; PetalBot;+https://aspiegel.com/petalbot)", "PetalBot")]
    [InlineData("WhatsApp/2.22.20.72 A", "WhatsApp")]
    [InlineData("WhatsApp/2.22.19.78 I", "WhatsApp")]
    [InlineData("WhatsApp/2.2236.3 N", "WhatsApp")]
    [InlineData("Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; Amazonbot/0.1; +developer.amazon.com/support/amazonbot) Chrome/119.0.6045.214 Safari/537.36", "Amazonbot")]
    [InlineData("Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; GPTBot/1.2; +openai.com/gptbot)", "GPTBot")]
    [InlineData("Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm) Chrome/116.0.1938.76 Safari/537.36", "BingBot")]
    [InlineData("Mozilla/5.0 (compatible; AwarioBot/1.0; +awario.com/bots.html)", "AwarioBot")]
    [InlineData("Mozilla/5.0 (compatible; DotBot/1.2; +opensiteexplorer.org/dotbot; help@moz.com)", "DotBot")]
    [InlineData("Mozilla/5.0 (Windows NT 10.0; Win64; x64; trendictionbot0.5.0; trendiction search; http://www.trendiction.de/bot; please let us know of any problems; web at trendiction.com) Gecko/20100101 Firefox/125.0", "trendictionbot")]
    [InlineData("Mozilla/5.0 (Linux; Android 5.0) AppleWebKit/537.36 (KHTML, like Gecko) Mobile Safari/537.36 (compatible; Bytespider; spider-feedback@bytedance.com)", "Bytespider")]
    [InlineData("Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; PerplexityBot/1.0; +perplexity.ai/perplexitybot)", "PerplexityBot")]
    [InlineData("Turnitin (bit.ly/2UvnfoQ)", "Turnitin")]
    [InlineData("meta-externalagent/1.1 (+developers.facebook.com/docs/sharing/webmasters/crawler)", "meta-externalagent")]
    [InlineData("CCBot/2.0 (commoncrawl.org/faq)", "CCBot")]
    [InlineData("Mozilla/5.0 (compatible; SeekportBot; +bot.seekport.com)", "SeekportBot")]
    [InlineData("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36; compatible; OAI-SearchBot/1.0; +openai.com/searchbot", "OAI-SearchBot")]
    [InlineData("Mozilla/5.0 (compatible; archive.org_bot +http://archive.org/details/archive.org_bot)", "archive.org")]
    [InlineData("Mozilla/5.0 (compatible; MojeekBot/0.11; +mojeek.com/bot.html)", "MojeekBot")]
    [InlineData("Mozilla/5.0 (compatible; CensysInspect/1.1; +https://about.censys.io/)", "CensysInspect")]
    [InlineData("Mozilla/5.0 (compatible; InternetMeasurement/1.0; +https://internet-measurement.com/)", "InternetMeasurement")]
    [InlineData("Mozilla/5.0 (compatible; Barkrowler/0.9; +https://babbar.tech/crawler)", "Barkrowler")]
    [InlineData("BrightEdge Crawler/1.0 (crawler@brightedge.com)", "BrightEdge")]
    [InlineData("Mozilla/5.0 (compatible; ImagesiftBot; +imagesift.com)", "ImagesiftBot")]
    [InlineData("Mozilla/5.0 (compatible; Cotoyogi/4.0; +https://ds.rois.ac.jp/center8/crawler/)", "Cotoyogi")]
    [InlineData("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/17.4 Safari/605.1.15 (Applebot/0.1; +http://www.apple.com/go/applebot)", "Applebot")]
    [InlineData("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36; 360Spider", "360Spider")]
    [InlineData("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko; GeedoProductSearch; +https://geedo.com/product-search.html) Chrome/134.0.0.0 Safari/537.36", "GeedoProductSearch")]
    public void BotTests(string ua, string name)
    {
        HttpUserAgentInformation uaInfo = HttpUserAgentInformation.Parse(ua);

        Assert.Equal(name, uaInfo.Name);
        Assert.Null(uaInfo.Version);
        Assert.Equal(ua, uaInfo.UserAgent);

        Assert.Equal(HttpUserAgentType.Robot, uaInfo.Type);

        Assert.Null(uaInfo.Platform);
        Assert.Null(uaInfo.MobileDeviceType);

        Assert.False(uaInfo.IsBrowser());
        Assert.False(uaInfo.IsMobile());
        Assert.True(uaInfo.IsRobot());
    }
}
