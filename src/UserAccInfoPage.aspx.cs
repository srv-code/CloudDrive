using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAccInfoPage : System.Web.UI.Page
{

    bool CheckForAnyErrors()
    {
        if (RadioButtonMale.Checked == false && RadioButtonFemale.Checked == false)
        {
            lblInfoUpdateConfirmation.Text = "Please choose a gender!"; return false;
        }
        if (DropDownListCountry.SelectedItem.Text == "Choose your country")
        {
            lblInfoUpdateConfirmation.Text = "Please choose a country!"; return false;
        }
        if (DropDownlistCity.SelectedItem.Text == "Choose your city")
        {
            lblInfoUpdateConfirmation.Text = "Please choose a city!"; return false;
        }
        if (txtPhNo.Text.Length < 5)
        {
            lblInfoUpdateConfirmation.Text = "Please enter your phone number!"; return false;
        }
        if (RadioButtonMarried.Checked == false && RadioButtonUnmarried.Checked == false)
        {
            lblInfoUpdateConfirmation.Text = "Please choose a martial status!"; return false;
        }
        return true;
    }
    void LoadCountries()
    {
        DropDownListCountry.Items.Clear();
        string[] countries = { "Choose your country", "Afghanistan", "Algeria", "Antarctica", "Argentina", "Australia", "Austria", "Bangladesh", "Belgium", "Bhutan", "Brazil", "Canada", "China", "Denmark", "Egypt", "France", "Georgia", "Germany", "Greece", "Hong Kong", "Iceland", "India", "Indonesia", "Iran", "Ireland", "Italy", "Jamaica", "Japan", "Libya", "Macau", "Madagascar", "Malaysia", "Mexico", "Nepal", "Netherlands", "New Zealand", "Pakistan", "Philippines", "Russia", "Saudi Arabia", "Singapore", "Spain", "Sri Lanka", "Switzerland", "Thailand", "Turkey", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Vietnam", "Zimbabwe" };
        foreach (string c in countries)
            DropDownListCountry.Items.Add(c);
    }
    void LoadCountryCode()
    {
        switch (DropDownListCountry.SelectedItem.Text)
        {
            case "Choose your country": txtPhNo.Text = ""; break;
            case "Afghanistan": txtPhNo.Text = "+93"; break;
            case "Algeria": txtPhNo.Text = "+213"; break;
            case "Antarctica": txtPhNo.Text = "+672"; break;
            case "Argentina": txtPhNo.Text = "+54"; break;
            case "Australia": txtPhNo.Text = "+61"; break;
            case "Austria": txtPhNo.Text = "+43"; break;
            case "Bangladesh": txtPhNo.Text = "+880"; break;
            case "Belgium": txtPhNo.Text = "+32"; break;
            case "Bhutan": txtPhNo.Text = "+975"; break;
            case "Brazil": txtPhNo.Text = "+55"; break;
            case "Canada": txtPhNo.Text = "+1"; break;
            case "China": txtPhNo.Text = "+86"; break;
            case "Denmark": txtPhNo.Text = "+45"; break;
            case "Egypt": txtPhNo.Text = "+20"; break;
            case "France": txtPhNo.Text = "+33"; break;
            case "Georgia": txtPhNo.Text = "+995"; break;
            case "Germany": txtPhNo.Text = "+49"; break;
            case "Greece": txtPhNo.Text = "+30"; break;
            case "Hong Kong": txtPhNo.Text = "+852"; break;
            case "Iceland": txtPhNo.Text = "+354"; break;
            case "India": txtPhNo.Text = "+91"; break;
            case "Indonesia": txtPhNo.Text = "+62"; break;
            case "Iran": txtPhNo.Text = "+98"; break;
            case "Ireland": txtPhNo.Text = "+353"; break;
            case "Italy": txtPhNo.Text = "+39"; break;
            case "Jamaica": txtPhNo.Text = "+1876"; break;
            case "Japan": txtPhNo.Text = "+81"; break;
            case "Libya": txtPhNo.Text = "+218"; break;
            case "Macau": txtPhNo.Text = "+853"; break;
            case "Madagascar": txtPhNo.Text = "+261"; break;
            case "Malaysia": txtPhNo.Text = "+60"; break;
            case "Mexico": txtPhNo.Text = "+52"; break;
            case "Nepal": txtPhNo.Text = "+977"; break;
            case "Netherlands": txtPhNo.Text = "+31"; break;
            case "New Zealand": txtPhNo.Text = "+64"; break;
            case "Pakistan": txtPhNo.Text = "+92"; break;
            case "Philippines": txtPhNo.Text = "+63"; break;
            case "Russia": txtPhNo.Text = "+7"; break;
            case "Saudi Arabia": txtPhNo.Text = "+966"; break;
            case "Singapore": txtPhNo.Text = "+65"; break;
            case "Spain": txtPhNo.Text = "+34"; break;
            case "Sri Lanka": txtPhNo.Text = "+94"; break;
            case "Switzerland": txtPhNo.Text = "+41"; break;
            case "Thailand": txtPhNo.Text = "+66"; break;
            case "Turkey": txtPhNo.Text = "+90"; break;
            case "Ukraine": txtPhNo.Text = "+380"; break;
            case "United Arab Emirates": txtPhNo.Text = "+971"; break;
            case "United Kingdom": txtPhNo.Text = "+44"; break;
            case "United States": txtPhNo.Text = "+1"; break;
            case "Vietnam": txtPhNo.Text = "+84"; break;
            case "Zimbabwe": txtPhNo.Text = "+263"; break;
            default: txtPhNo.Text = "+"; break;
        }
    }
    void LoadCountryCities()
    {
        DropDownlistCity.Items.Clear();
        switch (DropDownListCountry.SelectedItem.Text)
        {
            case "Choose your city":
                { break; }
            case "Afghanistan":
                {
                    string[] cities = { "Kabul", "Kandahar", "Herat", "Mazar-i-Sharif", "Kunduz", "Taloqan", "Jalalabad", "Puli Khumri", "Charikar", "Sheberghan", "Ghazni", "Sar-e Pol", "Khost", "Chaghcharan", "Mihtarlam", "Farah", "Pul-i-Alam", "Samangan", "Lashkar Gah" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Algeria":
                {
                    string[] cities = { "Alger", "Oran", "Constantine", "Annaba", "Blida", "Batna", "Djelfa", "Setif", "Sidi Bel Abbes", "Biskra", "Tebessa", "El Oued", "Skikda", "Tiaret", "Bejaia", "Tlemcen", "Ouargla", "Bechar", "Mostaganem", "Bordj Bou Arreridj", "Chief", "Souk Ahras", "Medea", "Touggourt", "Saida", "Jijel", "Guelma", "Khenchela", "Bousaada", "Mascara", "Tizi Aouzou" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Antarctica":
                {
                    string[] cities = { "Port Lockroy", "Stiman Portio", "Masen Lama", "Bajua", "Parada", "Surata", "Deception Island", "Neko Harbour", "Vernadsky", "Lemair", "Stuart Port" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Argentina":
                {
                    string[] cities = { "Corodoba", "Rosario", "Mendoza", "La Plata", "San Miguel de Tucuman", "Mar del Plata", "Salta", "Santa Fe", "San Juan", "Resistencia", "Neuquen", "Santiago del Estero", "Corrientes", "Bahia Blanca", "Launus" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Australia":
                {
                    string[] cities = { "Sydney", "Albury", "Armidale", "Bathurst", "Blue Mountains", "Broken Hill", "Campbelltown", "Orane", "Parramatta", "Penrith", "Tamworth", "Wollongong", "Newcastle", "Liverpool", "Dubbo" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Austria":
                {
                    string[] cities = { "Vienna", "Graz", "Linz", "Salzaburg", "Innsbruck", "Klagenfurt", "Wels", "Villach", "Sank Polten", "Dornbirn", "Wiener Neustadt", "Feldkirch", "Leonding", "Wolfsberg", "Leoben", "Krems", "Traun", "Modling", "HalleinSchwechat", "Stockerau", "Tulln", "Ternitz" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Bangladesh":
                {
                    string[] cities = { "Chittagong", "Rajshahi", "Khulna", "Barisal", "Sylhet", "Comilla", "Rangpur", "Narayanganj", "Gazipur", "Bandarban", "Brahmanbaria", "Shahbazarpur", "Chandpur", "Feni", "Laksam", "Lakshmipur", "Sandwip", "Faridpur", "Bhola", "Pirojpur", "Khulna", "Joypurhat", "Dhaka" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Belgium":
                {
                    string[] cities = { "Antwerp", "Suran", "Ghent", "Charleroi", "Brussels", "Surnama", "Antaraisur", "Namur", "Buran", "Mons", "Hasselt", "Tournai", "Sidenat", "Simons", "Genk", "Anama", "Tourkia", "Armania", "Viervers", "Denamal" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Bhutan":
                {
                    string[] cities = { "Thimpu", "Punakha", "Paro", "Geyelegphug", "Trashigang", "Wangdue Phodrang", "Taga Dzong", "Trongsa", "Phuntsholing", "Sampdrup Jongkhar", "Wangdue Phongra", "Samtse" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Brazil":
                {
                    string[] cities = { "Sao Paulo", "Ri de Jeneiro", "belo", "Horizonte", "Porto", "Alegre", "Brasillia", "Recife", "Fortaleza", "Salvador", "Curitiba", "Manaus", "Belem", "Vitoria", "Sao Luis", "Maceio", "Taearesina", "Campinas", "Goiana", "Belem", "Florianopolis" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Canada":
                {
                    string[] cities = { "Airdrie", "Brooks", "Calgary", "Camrose", "Cold Lake", "Edmonton", "Fort Saskatchewan", "Grande Prairie", "Lacombe", "Leduc", "Red Deer", "Spruce Grove", "St. Albert", "Wetaskiwin" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "China":
                {
                    string[] cities = { "Beijing", "Chongqing", "Shanghai", "Tianjin", "Hong Kong", "Macau", "Anqing", "Bengbu", "Bozhou", "Chaohu", "Fuyang", "Hefei", "Huaibei", "Huainan", "Lu’an", "Huangshan", "Ningguo", "Suzhou", "Tianchang", "Tongling", "Xuancheng", "Changle", "Fuding" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Denmark":
                {
                    string[] cities = { "Copenhangen", "Aarhus", "Adense", "Aalborg", "Frederiksberg", "Esbjerg", "Gentofte", "Gladsaxe", "Randers", "Kolding", "Horsens", "Vejle", "Hvidovre", "Roskilde", "Helsinger", "Herning", "Silkeborg", "Fredericia", "Ballerup", "Viborg", "Holberg" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Egypt":
                {
                    string[] cities = { "Cairo", "Alexandria", "Giza", "Port Said", "Suez", "El-Mahalla El-Kubra", "al-Mansura", "Luxor", "Tanta", "Asyut", "Ismilia", "Fayyum", "Zagazig", "Aswan", "Damietta", "Damanhur", "al-Minya", "Beni Suef", "Qena", "Sohag", "Hurghada", "Shibin El Kom", "Arish" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "France":
                {
                    string[] cities = { "Paris", "Lyon", "Nice", "Marseillie", "Toulouse", "Nantes", "Bordeaux", "Lille", "Rennes", "Le Havre", "Toulon", "Grenoble", "Angers", "Brest", "Dijon", "Amiens", "Limoges", "Nimes", "Tours", "Metz", "Caen", "Orleans", "Boulogne", "Nancy", "Fort-de-France", "Montreal", "Nanterre" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Georgia":
                {
                    string[] cities = { "Tbillisi", "Kutaisi", "Batumi", "Rustavi", "Zugdidi", "Gori", "Poti", "Samtredia", "Khashuri", "Senaki", "Zetafoni", "Marneuli", "Telavi", "Akhaltsikhe", "Kobuleti", "Azurgeti", "Tsqualtubo", "Kaspi", "Chinaturi", "Bolinis", "Khoni" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Germany":
                {
                    string[] cities = { "Bavaria", "Baden-Wurttemberg", "North-Rhine-Westhalia", "Hesse", "Lower Saxony", "Rhineland-Palatinate", "Thuringia", "Brandenburg", "Saxony-Anhalt", "Saarland", "Bremen", "Berlin", "Hamburg" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Greece":
                {
                    string[] cities = { "Athens", "Thessaloniki", "Patras", "Piraeus", "Larissa", "Heraklion", "Peristeri", "Kallithea", "Acharnes", "Nikaia", "Glyfada", "Volos", "Ilio", "Ilioupoli", "Keratsini", "Evosmos", "Chalandri", "Nea Smyrni", "Maousi", "Zografou", "Nea Ionia", "Ioannina", "Palaio Faliro", "Trikala", "Vyronas", "Chalcia", "Serres" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Hong Kong":
                {
                    string[] cities = { "Aberdeen", "Cheung Chau", "Discovery Bay", "Jardine’s Lookout", "Kennedy Town", "Kwun Tong", "Lei Yue Mun", "Ma Wan", "Mui Wo (Silvermine Bay)", "Peng Chau", "Sai Kung", "Sha Tau Kok", "Shek O", "Sok Kwu Wan", "Stanley", "Tai O", "Yuen Long Town" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Iceland":
                {
                    string[] cities = { "Reykjavik", "Kopavogur", "Hafnarfjorour", "Akureyri", "Norourland eystra", "Akranes", "Selfoss", "Mosfellsbear", "Grindavik", "Isafjorour", "Sauoarkrokur", "Husavik", "Borgarnes", "Dalvik", "Neskaupstaou" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "India":
                {
                    string[] cities = { "Agartala", "Agra", "Ahmedabad", "Allahabad", "Amritsar", "Andaman and Nicobar Island", "Aurangabad", "Ayodha", "Badrinath", "Bangalore", "Baroda", "Bhagalpur", "Bhopal", "Bhubaneshwar", "Calicut", "Chennai", "Chandigarh", "Chidambaram", "Coimbatore", "Cuttak", "Dehradun", "Darjeeling", "Delhi", "Faridabad", "Gandhinagar", "Gantok", "Goa", "Gwalior", "Gurgaon", "Guwahati", "Haridwar", "Hyderabad", "Indore", "Jaipur", "Jabalpur", "Jaisalmer", "Jammu", "Jamshedpur", "Jodhpur", "Kanpur", "Kanyakumari", "Kedarnath", "Kochi", "Kolkata", "Konark", "Lucknow", "Ludhiana", "Mangalore", "Mumbai", "Mysore", "Ooty", "Pondicherry", "Puri", "Patna", "Pune", "Pushkar", "Ranchi", "Rourkela", "Shimla", "Srinagar", "Shillong", "Surat", "Trichy", "Thiruvananthapuram", "Tirupati", "Varanasi", "Vishakhapatnam", "Warangal" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Indonesia":
                {
                    string[] cities = { "Jakarta", "Surabaya", "Bandung", "Bekasi", "Medan", "Tangerrang", "Depok", "Semarang", "Palembang", "Makassar", "Batam", "Pekanbaru", "Bogor", "Padang", "Denpasar", "Malang" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Iran":
                {
                    string[] cities = { "Aberdeen", "Cheung Chau", "Discovery Bay", "Jardine’s Lookout", "Kennedy Town", "Kwun Tong", "Lei Yue Mun", "Ma Wan", "Mui Wo (Silvermine Bay)", "Peng Chau", "Sai Kung", "Sha Tau Kok", "Shek O", "Sok Kwu Wan", "Stanley", "Tai O", "Yuen Long Town" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Ireland":
                {
                    string[] cities = { "Antwerp", "Suran", "Ghent", "Charleroi", "Brussels", "Surnama", "Antaraisur", "Namur", "Buran", "Mons", "Hasselt", "Tournai", "Sidenat", "Simons", "Genk", "Anama", "Tourkia", "Armania", "Viervers", "Denamal" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Italy":
                {
                    string[] cities = { "Reykjavik", "Kopavogur", "Hafnarfjorour", "Akureyri", "Norourland eystra", "Akranes", "Selfoss", "Mosfellsbear", "Grindavik", "Isafjorour", "Sauoarkrokur", "Husavik", "Borgarnes", "Dalvik", "Neskaupstaou" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Jamaica":
                {
                    string[] cities = { "Vienna", "Graz", "Linz", "Salzaburg", "Innsbruck", "Klagenfurt", "Wels", "Villach", "Sank Polten", "Dornbirn", "Wiener Neustadt", "Feldkirch", "Leonding", "Wolfsberg", "Leoben", "Krems", "Traun", "Modling", "HalleinSchwechat", "Stockerau", "Tulln", "Ternitz" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Japan":
                {
                    string[] cities = { "Reykjavik", "Kopavogur", "Hafnarfjorour", "Akureyri", "Norourland eystra", "Akranes", "Selfoss", "Mosfellsbear", "Grindavik", "Isafjorour", "Sauoarkrokur", "Husavik", "Borgarnes", "Dalvik", "Neskaupstaou" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Libya":
                {
                    string[] cities = { "Antwerp", "Suran", "Ghent", "Charleroi", "Brussels", "Surnama", "Antaraisur", "Namur", "Buran", "Mons", "Hasselt", "Tournai", "Sidenat", "Simons", "Genk", "Anama", "Tourkia", "Armania", "Viervers", "Denamal" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Macau":
                {
                    string[] cities = { "Corodoba", "Rosario", "Mendoza", "La Plata", "San Miguel de Tucuman", "Mar del Plata", "Salta", "Santa Fe", "San Juan", "Resistencia", "Neuquen", "Santiago del Estero", "Corrientes", "Bahia Blanca", "Launus" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Madagascar":
                {
                    string[] cities = { "Aberdeen", "Cheung Chau", "Discovery Bay", "Jardine’s Lookout", "Kennedy Town", "Kwun Tong", "Lei Yue Mun", "Ma Wan", "Mui Wo (Silvermine Bay)", "Peng Chau", "Sai Kung", "Sha Tau Kok", "Shek O", "Sok Kwu Wan", "Stanley", "Tai O", "Yuen Long Town" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Malaysia":
                {
                    string[] cities = { "Penang", "Kuala Lumpur", "Ipoh", "Kuching", "Cyberjaya", "Shah Alam", "Kota Kinabalu", "Malacca", "Miri", "Alor Setar", "Kuala Terengganu", "Johor Bahrua", "Kuching" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Mexico":
                {
                    string[] cities = { "Sao Paulo", "Ri de Jeneiro", "belo", "Horizonte", "Porto", "Alegre", "Brasillia", "Recife", "Fortaleza", "Salvador", "Curitiba", "Manaus", "Belem", "Vitoria", "Sao Luis", "Maceio", "Taearesina", "Campinas", "Goiana", "Belem", "Florianopolis" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Nepal":
                {
                    string[] cities = { "Kathmandu", "Pokhara", "Lalitpur", "Birganj", "Bharatpur", "Janakpur", "Biratnapur", "Butwal", "Dharan", "Dhangandhi", "Hetauda", "Damak", "Itahari", "Nepaljang", "Kirtipur", "Ghorahi", "Lekhnath", "Birendranagar", "Byas", "Kalaiya", "Gaur", "Lahan", "Gorkha", "Baglung", "Tansen", "Bidur", "Khandbari", "Malangwa", "Banepa" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Netherlands":
                {
                    string[] cities = { "Alger", "Oran", "Constantine", "Annaba", "Blida", "Batna", "Djelfa", "Setif", "Sidi Bel Abbes", "Biskra", "Tebessa", "El Oued", "Skikda", "Tiaret", "Bejaia", "Tlemcen", "Ouargla", "Bechar", "Mostaganem", "Bordj Bou Arreridj", "Chief", "Souk Ahras", "Medea", "Touggourt", "Saida", "Jijel", "Guelma", "Khenchela", "Bousaada", "Mascara", "Tizi Aouzou" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "New Zealand":
                {
                    string[] cities = { "Tbillisi", "Kutaisi", "Batumi", "Rustavi", "Zugdidi", "Gori", "Poti", "Samtredia", "Khashuri", "Senaki", "Zetafoni", "Marneuli", "Telavi", "Akhaltsikhe", "Kobuleti", "Azurgeti", "Tsqualtubo", "Kaspi", "Chinaturi", "Bolinis", "Khoni" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Pakistan":
                {
                    string[] cities = { "Quetta", "Sibi", "Chaman", "Lasbela", "Nasirabad", "Peshawar", "Swabi", "Charsadda", "Lahore", "Rawalpindi", "Bahawalpur", "Sukkur", "Khairpur", "Kotli", "Hattain", "Sharda", "Khaar", "Landi Kotal", "Jamrud", "Gigit", "Faizan", "Ghanche", "Gojal" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Philippines":
                {
                    string[] cities = { "Jakarta", "Surabaya", "Bandung", "Bekasi", "Medan", "Tangerrang", "Depok", "Semarang", "Palembang", "Makassar", "Batam", "Pekanbaru", "Bogor", "Padang", "Denpasar", "Malang" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Russia":
                {
                    string[] cities = { "Aabza", "Abdulino", "Agidel", "Aksay", "Alagir", "Aleksin", "Aleysin", "Anapa", "Baksan", "Balakovo", "Barnaul", "Barysh", "Belaya Kaliyata", " Kirov Oblava", "Belomorsk", "Belovo", "Bikin", "Cherepong", "Chudovo", "Chulym", "Dagestan", "Darbang", "Dmitrov", "Bonskoy", "Dudkina", "Elekrovo", "Limbono", "Isalava", "Sumatina" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Saudi Arabia":
                {
                    string[] cities = { "Aberdeen", "Cheung Chau", "Discovery Bay", "Jardine’s Lookout", "Kennedy Town", "Kwun Tong", "Lei Yue Mun", "Ma Wan", "Mui Wo (Silvermine Bay)", "Peng Chau", "Sai Kung", "Sha Tau Kok", "Shek O", "Sok Kwu Wan", "Stanley", "Tai O", "Yuen Long Town" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Singapore":
                {
                    string[] cities = { "Alijua", "Ang Mo Kio", "Cheng San", "Tek Ghee", "Bekod", "Bukit Panjang", "Bukit Timang", "Bouna Vista", "Chinatown", "Pandan Valley", "Dover", "Geyland East", "Houngang", "Jalan Kayu", "Boon Lay", "Yuhua", "Jurong", "Chin Bee", "Kallang", "Labrador Park", "Kent Ridge" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Spain":
                {
                    string[] cities = { "Airdrie", "Brooks", "Calgary", "Camrose", "Cold Lake", "Edmonton", "Fort Saskatchewan", "Grande Prairie", "Lacombe", "Leduc", "Red Deer", "Spruce Grove", "St. Albert", "Wetaskiwin" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Sri Lanka":
                {
                    string[] cities = { "Colombo", "Dehiwala-Mount Lavinia", "Moratuwa", "Sri Jayawardenapura Kotte", "Negombo", "Kandy", "Kalmunai", "Vavuniya", "Galle", "Trincomalee", "Batticaloa", "Jaffna", "Katunayake", "Dambulla", "Kolonnawa", "Anuradhapura", "Ratnapura", "Badulla", "Matara", "Puttalam", "Chavakacheri", "Kattankudy" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Switzerland":
                {
                    string[] cities = { "Aarau", "Agno", "Aigle", "Appenzell", "Ascona", "Aubonne", "Baden", "Basel", "Biasca", "Boudry", "Bulle", "Carouge", "Chur", "Coppet", "Cully", "Davos", "Surua", "Lisapun", "Eglisas", "Fribourg", "Gland", "Gordola", "Grandson, Horw", "Ilanz", "Kloten", "Nauchatel", "Le Loche" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Thailand":
                {
                    string[] cities = { "Vienna", "Graz", "Linz", "Salzaburg", "Innsbruck", "Klagenfurt", "Wels", "Villach", "Sank Polten", "Dornbirn", "Wiener Neustadt", "Feldkirch", "Leonding", "Wolfsberg", "Leoben", "Krems", "Traun", "Modling", "HalleinSchwechat", "Stockerau", "Tulln", "Ternitz" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Turkey":
                {
                    string[] cities = { "Antwerp", "Suran", "Ghent", "Charleroi", "Brussels", "Surnama", "Antaraisur", "Namur", "Buran", "Mons", "Hasselt", "Tournai", "Sidenat", "Simons", "Genk", "Anama", "Tourkia", "Armania", "Viervers", "Denamal" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Ukraine":
                {
                    string[] cities = { "Airdrie", "Brooks", "Calgary", "Camrose", "Cold Lake", "Edmonton", "Fort Saskatchewan", "Grande Prairie", "Lacombe", "Leduc", "Red Deer", "Spruce Grove", "St. Albert", "Wetaskiwin" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "United Arab Emirates":
                {
                    string[] cities = { "Aberdeen", "Cheung Chau", "Discovery Bay", "Jardine’s Lookout", "Kennedy Town", "Kwun Tong", "Lei Yue Mun", "Ma Wan", "Mui Wo (Silvermine Bay)", "Peng Chau", "Sai Kung", "Sha Tau Kok", "Shek O", "Sok Kwu Wan", "Stanley", "Tai O", "Yuen Long Town" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "United Kingdom":
                {
                    string[] cities = { "Bath", "Birmingham", "Bradford", "Brighton & Hove", "Bristol", "Cambridge", "Canterbury", "Carlisle", "Chelmsford", "Chester", "Chichester", "Coventry", "Derby", "Durham", "Exeter", "Gloucester", "Hereford", "Kingston upon Hull", "Lancaster", "Leeds" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "United States":
                {
                    string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Philadelphia", "Phoenix", "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Indianapolis", "Jacksonville", "San Francisco", "Columbus", "Charlotte", "Fort Worth", "Detroit", "El Paso", "Memphis", "Seattle", "Denver", "Washington", "Boston", "Nashville", "Portland", "Las Vegas", "Albuquerque", "Atlanta", "Omaha", "Miami", "Oakland" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Vietnam":
                {
                    string[] cities = { "Antwerp", "Suran", "Ghent", "Charleroi", "Brussels", "Surnama", "Antaraisur", "Namur", "Buran", "Mons", "Hasselt", "Tournai", "Sidenat", "Simons", "Genk", "Anama", "Tourkia", "Armania", "Viervers", "Denamal" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
            case "Zimbabwe":
                {
                    string[] cities = { "Aberdeen", "Cheung Chau", "Discovery Bay", "Jardine’s Lookout", "Kennedy Town", "Kwun Tong", "Lei Yue Mun", "Ma Wan", "Mui Wo (Silvermine Bay)", "Peng Chau", "Sai Kung", "Sha Tau Kok", "Shek O", "Sok Kwu Wan", "Stanley", "Tai O", "Yuen Long Town" };
                    foreach (string s in cities)
                        DropDownlistCity.Items.Add(s);
                    break;
                }
        }
    }
    void Show_LoggedInAsMsg()
    {
        try
        {
            lblLoggedInAs.Text = "Logged In As " + Session["user"];
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            // var res = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"] select v;
            var res = DB.UserInfos.Where(x => x.Username == Session["user"]);
            foreach (var r in res)
            {
                ImageProPic.ImageUrl = r.UserProfilePicFile;
                if (ImageProPic.ImageUrl == "")
                {
                    if (r.UserGender == "Male")
                        ImageProPic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png";
                    else
                        ImageProPic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png";
                }
                else
                    ImageProPic.ImageUrl = r.UserProfilePicFile;
            }
            HyperLinkVisitAcc.NavigateUrl = "CustomerPage.aspx";
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void UpdateUserInfo()
    {
        if (CheckForAnyErrors())
        {
            if (CheckBoxAgreeTerms.Checked == true)
            {
                FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                // var res = from v in DB.GetTable<UserInfo>() where v.Username == txtUsername.Text select v;
                var res = DB.UserInfos.Where(x => x.Username == txtUsername.Text);
                foreach (var r in res)
                {
                    r.UserFirstName = txtFirstName.Text;
                    r.UserMiddleName = txtMiddleName.Text;
                    r.UserLastName = txtLastName.Text;
                    if (RadioButtonMale.Checked)
                        r.UserGender = "Male";
                    else
                        r.UserGender = "Female";
                    r.UserDOB = txtDOB.Text;
                    r.UserCountry = DropDownListCountry.SelectedItem.Text;
                    r.UserCity = DropDownlistCity.SelectedItem.Text;
                    r.UserPhoneNumber = txtPhNo.Text;
                    if (RadioButtonMarried.Checked)
                        r.UserMartialStatus = "y";
                    else
                        r.UserMartialStatus = "n";
                    r.UserEMail = txtEMail.Text;
                    if (TextBoxCustomSecurityQuestion.Visible = true && DropDownListSecurityQuestion.SelectedItem.Text == "Create a question yourself")
                        r.UserSecurityQuestion = TextBoxCustomSecurityQuestion.Text;
                    else
                        r.UserSecurityQuestion = DropDownListSecurityQuestion.SelectedItem.Text;
                    r.UserSecurityAnswer = txtSecurityAnswer.Text;
                }
                DB.SubmitChanges();
                lblInfoUpdateConfirmation.Text = "Congratulation! Information successfully updated!";
                lblAgreeConfirmation.Text = "";
            }
            else
            {
                lblAgreeConfirmation.Text = "You must check the Terms and Policy checkbox for remaining a user of this site!";
            }
        }
    }
    void DisplayUserInfo()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            // var res = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"] select v;
            var res = DB.UserInfos.Where(x => x.Username == Session["user"]);
            foreach (var r in res)
            {
                txtUsername.Text = r.Username;
                txtFirstName.Text = r.UserFirstName;
                txtMiddleName.Text = r.UserMiddleName;
                txtLastName.Text = r.UserLastName;
                if (r.UserGender == "Male")
                    RadioButtonMale.Checked = true;
                else
                    RadioButtonFemale.Checked = true;
                txtDOB.Text = r.UserDOB;
                DropDownListCountry.SelectedItem.Text = r.UserCountry;
                DropDownlistCity.Items.Add(r.UserCity);
                txtPhNo.Text = r.UserPhoneNumber;
                if (r.UserMartialStatus == "y")
                    RadioButtonMarried.Checked = true;
                else
                    RadioButtonUnmarried.Checked = true;
                txtEMail.Text = r.UserEMail;
                DropDownListSecurityQuestion.SelectedItem.Text = r.UserSecurityQuestion;
                txtSecurityAnswer.Text = r.UserSecurityAnswer;
                CheckBoxAgreeTerms.Checked = true;
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void Logout()
    {
        Session.Abandon();
        Response.Redirect("Homepage.aspx?s=1");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Show_LoggedInAsMsg();
    }
    protected void btnUpdateInfo_Click(object sender, EventArgs e)
    {
        UpdateUserInfo();
    }
    protected void LinkButtonUserLogout_Click(object sender, EventArgs e)
    {
        Logout();
    }
    protected void btnLoadInfo_Click(object sender, EventArgs e)
    {
        PanelUserInfo2.Enabled = true;
        LoadCountries();
        DisplayUserInfo();
    }
    protected void DropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCountryCities();
        LoadCountryCode();
    }
    protected void DropDownListSecurityQuestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListSecurityQuestion.SelectedItem.Text == "Create a question yourself")
            TextBoxCustomSecurityQuestion.Visible = true;
        else
            TextBoxCustomSecurityQuestion.Visible = false;
        
    }
}