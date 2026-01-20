using System.Collections.Generic;

namespace InnoteksoWeb.Models
{
    /// <summary>
    /// Model for service package information - Updated with 50% reduced prices
    /// </summary>
    public class ServicePackageModel
    {
        public string Id { get; set; }
        public string ServiceType { get; set; }
        public string PackageName { get; set; }
        public string PackageSubtitle { get; set; }
        public string IconClass { get; set; }
        public string PriceRange { get; set; }
        public string PricePeriod { get; set; }
        public List<string> Features { get; set; }
        public bool IsPopular { get; set; }
        public string ButtonText { get; set; }
        public string ButtonAction { get; set; }

        public ServicePackageModel()
        {
            Features = new List<string>();
            ButtonText = "Get Started";
        }
    }

    /// <summary>
    /// Tech stack item for displaying technologies
    /// </summary>
    public class TechStackItem
    {
        public string Name { get; set; }
        public string IconClass { get; set; }
        public string Category { get; set; }
    }

    /// <summary>
    /// Service section configuration
    /// </summary>
    public class ServiceSectionModel
    {
        public string Id { get; set; }
        public string ServiceType { get; set; }
        public string BadgeText { get; set; }
        public string BadgeIcon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ServicePackageModel> Packages { get; set; }
        public List<TechStackItem> TechStack { get; set; }

        public ServiceSectionModel()
        {
            Packages = new List<ServicePackageModel>();
            TechStack = new List<TechStackItem>();
        }
    }

    /// <summary>
    /// Helper class to generate all service packages with updated 50% reduced pricing
    /// </summary>
    public static class ServicePackagesData
    {
        /// <summary>
        /// Get Web Development packages - Updated Pricing
        /// </summary>
        public static ServiceSectionModel GetWebDevelopmentSection()
        {
            return new ServiceSectionModel
            {
                Id = "web-development",
                ServiceType = "Web Development",
                BadgeText = "Professional Web Development",
                BadgeIcon = "fas fa-code",
                Title = "Web Development Packages",
                Description = "Custom-built websites and web applications designed to elevate your online presence and drive business growth. From simple landing pages to complex web platforms.",
                Packages = new List<ServicePackageModel>
                {
                    new ServicePackageModel
                    {
                        Id = "web-starter",
                        ServiceType = "Web Development",
                        PackageName = "Starter Website",
                        PackageSubtitle = "Perfect for Small Businesses",
                        IconClass = "fas fa-laptop-code",
                        PriceRange = "R7,500 - R12,500",
                        PricePeriod = "one-time",
                        IsPopular = false,
                        Features = new List<string>
                        {
                            "Up to 5 pages",
                            "Responsive design (mobile-friendly)",
                            "Contact form integration",
                            "Basic SEO optimization",
                            "Social media integration",
                            "Google Maps integration",
                            "SSL certificate setup",
                            "1 month free maintenance",
                            "Domain & hosting guidance",
                            "Training session included"
                        }
                    },
                    new ServicePackageModel
                    {
                        Id = "web-professional",
                        ServiceType = "Web Development",
                        PackageName = "Professional Website",
                        PackageSubtitle = "Ideal for Growing Companies",
                        IconClass = "fas fa-globe",
                        PriceRange = "R15,000 - R30,000",
                        PricePeriod = "one-time",
                        IsPopular = true,
                        Features = new List<string>
                        {
                            "Up to 15 pages",
                            "Custom design & branding",
                            "Advanced animations & effects",
                            "Content Management System (CMS)",
                            "Blog functionality",
                            "Email newsletter integration",
                            "Advanced SEO optimization",
                            "Analytics dashboard setup",
                            "E-commerce ready (up to 50 products)",
                            "Payment gateway integration",
                            "Live chat integration",
                            "3 months free maintenance",
                            "Priority support"
                        }
                    },
                    new ServicePackageModel
                    {
                        Id = "web-enterprise",
                        ServiceType = "Web Development",
                        PackageName = "Enterprise Platform",
                        PackageSubtitle = "Custom Web Applications",
                        IconClass = "fas fa-server",
                        PriceRange = "R40,000+",
                        PricePeriod = "custom quote",
                        IsPopular = false,
                        ButtonText = "Contact Us",
                        Features = new List<string>
                        {
                            "Unlimited pages",
                            "Fully custom web application",
                            "Advanced user management",
                            "Database architecture & design",
                            "API development & integration",
                            "Third-party integrations",
                            "Multi-language support",
                            "Advanced security features",
                            "Load balancing & optimization",
                            "Custom reporting & analytics",
                            "Progressive Web App (PWA)",
                            "6 months free maintenance",
                            "Dedicated project manager",
                            "24/7 priority support"
                        }
                    }
                },
                TechStack = new List<TechStackItem>
                {
                    new TechStackItem { Name = "React", IconClass = "fab fa-react", Category = "Frontend" },
                    new TechStackItem { Name = "Angular", IconClass = "fab fa-angular", Category = "Frontend" },
                    new TechStackItem { Name = "Node.js", IconClass = "fab fa-node-js", Category = "Backend" },
                    new TechStackItem { Name = "Python", IconClass = "fab fa-python", Category = "Backend" },
                    new TechStackItem { Name = "PHP", IconClass = "fab fa-php", Category = "Backend" },
                    new TechStackItem { Name = "SQL", IconClass = "fas fa-database", Category = "Database" },
                    new TechStackItem { Name = "WordPress", IconClass = "fab fa-wordpress", Category = "CMS" },
                    new TechStackItem { Name = "Azure", IconClass = "fas fa-cloud", Category = "Cloud" }
                }
            };
        }

        /// <summary>
        /// Get Mobile Applications packages - Updated Pricing
        /// </summary>
        public static ServiceSectionModel GetMobileAppsSection()
        {
            return new ServiceSectionModel
            {
                Id = "mobile-apps",
                ServiceType = "Mobile Applications",
                BadgeText = "Mobile App Development",
                BadgeIcon = "fas fa-mobile-alt",
                Title = "Mobile Application Packages",
                Description = "Native and cross-platform mobile applications for iOS and Android. Engage your customers with powerful mobile experiences.",
                Packages = new List<ServicePackageModel>
                {
                    new ServicePackageModel
                    {
                        Id = "mobile-basic",
                        ServiceType = "Mobile Applications",
                        PackageName = "Basic App",
                        PackageSubtitle = "Simple Mobile Application",
                        IconClass = "fas fa-mobile",
                        PriceRange = "R20,000 - R40,000",
                        PricePeriod = "per platform",
                        IsPopular = false,
                        Features = new List<string>
                        {
                            "iOS or Android (single platform)",
                            "Up to 10 screens",
                            "User authentication (login/signup)",
                            "Basic user profile",
                            "Push notifications",
                            "In-app messaging",
                            "Basic API integration",
                            "Offline functionality",
                            "App store submission",
                            "2 months support"
                        }
                    },
                    new ServicePackageModel
                    {
                        Id = "mobile-professional",
                        ServiceType = "Mobile Applications",
                        PackageName = "Professional App",
                        PackageSubtitle = "Cross-Platform Solution",
                        IconClass = "fas fa-tablet-alt",
                        PriceRange = "R50,000 - R100,000",
                        PricePeriod = "both platforms",
                        IsPopular = true,
                        Features = new List<string>
                        {
                            "iOS & Android (both platforms)",
                            "Up to 25 screens",
                            "Custom UI/UX design",
                            "Advanced user profiles",
                            "Social media integration",
                            "Payment gateway integration",
                            "Geolocation & maps",
                            "Photo/video capture & upload",
                            "In-app purchases",
                            "Analytics integration",
                            "Backend dashboard",
                            "Advanced API integrations",
                            "App store optimization",
                            "4 months support"
                        }
                    },
                    new ServicePackageModel
                    {
                        Id = "mobile-enterprise",
                        ServiceType = "Mobile Applications",
                        PackageName = "Enterprise App",
                        PackageSubtitle = "Full-Featured Platform",
                        IconClass = "fas fa-mobile-alt",
                        PriceRange = "R125,000+",
                        PricePeriod = "custom quote",
                        IsPopular = false,
                        ButtonText = "Contact Us",
                        Features = new List<string>
                        {
                            "iOS & Android native apps",
                            "Unlimited screens",
                            "Fully custom features",
                            "Advanced security (biometrics)",
                            "Real-time data synchronization",
                            "Video streaming capabilities",
                            "AI/ML integration",
                            "Augmented Reality (AR)",
                            "Multi-language support",
                            "Advanced analytics & reporting",
                            "Admin & customer portals",
                            "Third-party integrations",
                            "Scalable cloud backend",
                            "6 months priority support",
                            "Dedicated development team"
                        }
                    }
                },
                TechStack = new List<TechStackItem>
                {
                    new TechStackItem { Name = "React Native", IconClass = "fab fa-react", Category = "Mobile" },
                    new TechStackItem { Name = "Flutter", IconClass = "fas fa-mobile-alt", Category = "Mobile" },
                    new TechStackItem { Name = "iOS Native", IconClass = "fab fa-apple", Category = "Mobile" },
                    new TechStackItem { Name = "Android Native", IconClass = "fab fa-android", Category = "Mobile" },
                    new TechStackItem { Name = "Firebase", IconClass = "fas fa-fire", Category = "Backend" },
                    new TechStackItem { Name = "MongoDB", IconClass = "fas fa-database", Category = "Database" },
                    new TechStackItem { Name = "Node.js", IconClass = "fab fa-node-js", Category = "Backend" },
                    new TechStackItem { Name = "AWS", IconClass = "fas fa-cloud", Category = "Cloud" }
                }
            };
        }

        /// <summary>
        /// Get Cloud & AI Solutions packages - Updated Pricing
        /// </summary>
        public static ServiceSectionModel GetCloudAISection()
        {
            return new ServiceSectionModel
            {
                Id = "cloud-ai",
                ServiceType = "Cloud & AI Solutions",
                BadgeText = "Cloud & AI Solutions",
                BadgeIcon = "fas fa-cloud",
                Title = "Cloud & AI Packages",
                Description = "Harness the power of cloud computing and artificial intelligence to transform your business operations and unlock new possibilities.",
                Packages = new List<ServicePackageModel>
                {
                    new ServicePackageModel
                    {
                        Id = "cloud-essentials",
                        ServiceType = "Cloud & AI Solutions",
                        PackageName = "Cloud Essentials",
                        PackageSubtitle = "Cloud Migration & Setup",
                        IconClass = "fas fa-cloud-upload-alt",
                        PriceRange = "R15,000 - R30,000",
                        PricePeriod = "one-time + monthly hosting",
                        IsPopular = false,
                        Features = new List<string>
                        {
                            "Cloud platform setup (Azure/AWS)",
                            "Data migration to cloud",
                            "Cloud storage configuration",
                            "Automated backups",
                            "Basic security setup",
                            "User access management",
                            "Email hosting (Office 365)",
                            "File sharing & collaboration",
                            "Monitoring & alerts",
                            "3 months support"
                        }
                    },
                    new ServicePackageModel
                    {
                        Id = "ai-integration",
                        ServiceType = "Cloud & AI Solutions",
                        PackageName = "AI Integration",
                        PackageSubtitle = "Intelligent Automation",
                        IconClass = "fas fa-brain",
                        PriceRange = "R40,000 - R75,000",
                        PricePeriod = "project-based",
                        IsPopular = true,
                        Features = new List<string>
                        {
                            "AI chatbot implementation",
                            "Natural language processing",
                            "Document analysis & extraction",
                            "Image recognition & tagging",
                            "Predictive analytics",
                            "Machine learning models",
                            "Data visualization dashboards",
                            "Workflow automation",
                            "API integrations",
                            "Custom AI training",
                            "Performance monitoring",
                            "Cloud infrastructure",
                            "6 months support & optimization"
                        }
                    },
                    new ServicePackageModel
                    {
                        Id = "enterprise-cloud",
                        ServiceType = "Cloud & AI Solutions",
                        PackageName = "Enterprise Cloud",
                        PackageSubtitle = "Complete Digital Transformation",
                        IconClass = "fas fa-network-wired",
                        PriceRange = "R100,000+",
                        PricePeriod = "custom solution",
                        IsPopular = false,
                        ButtonText = "Contact Us",
                        Features = new List<string>
                        {
                            "Full cloud architecture design",
                            "Multi-region deployment",
                            "Advanced AI/ML pipelines",
                            "Big data processing",
                            "IoT integration & management",
                            "Blockchain implementation",
                            "Advanced security & compliance",
                            "Disaster recovery planning",
                            "DevOps & CI/CD pipelines",
                            "Container orchestration (Kubernetes)",
                            "Microservices architecture",
                            "Custom AI model development",
                            "24/7 monitoring & support",
                            "Dedicated cloud architect",
                            "Ongoing optimization"
                        }
                    }
                },
                TechStack = new List<TechStackItem>
                {
                    new TechStackItem { Name = "Azure", IconClass = "fab fa-microsoft", Category = "Cloud" },
                    new TechStackItem { Name = "AWS", IconClass = "fab fa-aws", Category = "Cloud" },
                    new TechStackItem { Name = "Google Cloud", IconClass = "fab fa-google", Category = "Cloud" },
                    new TechStackItem { Name = "TensorFlow", IconClass = "fas fa-brain", Category = "AI" },
                    new TechStackItem { Name = "OpenAI", IconClass = "fas fa-robot", Category = "AI" },
                    new TechStackItem { Name = "Python", IconClass = "fab fa-python", Category = "AI" },
                    new TechStackItem { Name = "Kubernetes", IconClass = "fas fa-dharmachakra", Category = "DevOps" },
                    new TechStackItem { Name = "Docker", IconClass = "fab fa-docker", Category = "DevOps" }
                }
            };
        }

        /// <summary>
        /// Get Smart Home packages - Updated Pricing
        /// </summary>
        public static ServiceSectionModel GetSmartHomeSection()
        {
            return new ServiceSectionModel
            {
                Id = "smart-home",
                ServiceType = "Smart Home",
                BadgeText = "Professional Smart Home Solutions",
                BadgeIcon = "fas fa-home",
                Title = "Smart Home Packages",
                Description = "Transform your home into an intelligent living space with our comprehensive IoT solutions. Professional installation and ongoing support included.",
                Packages = new List<ServicePackageModel>
                {
                    new ServicePackageModel
                    {
                        Id = "smart-starter",
                        ServiceType = "Smart Home",
                        PackageName = "Starter Package",
                        PackageSubtitle = "Essential Smart Home",
                        IconClass = "fas fa-lightbulb",
                        PriceRange = "R12,500 - R20,000",
                        PricePeriod = "one-time installation",
                        IsPopular = false,
                        Features = new List<string>
                        {
                            "Smart lighting (5 bulbs)",
                            "Smart power plugs (3 units)",
                            "Voice assistant setup (1 hub)",
                            "Mobile app configuration",
                            "Basic automation scenes",
                            "Professional installation",
                            "User training session",
                            "3 months support"
                        }
                    },
                    new ServicePackageModel
                    {
                        Id = "smart-advanced",
                        ServiceType = "Smart Home",
                        PackageName = "Advanced Package",
                        PackageSubtitle = "Complete Home Automation",
                        IconClass = "fas fa-home",
                        PriceRange = "R25,000 - R40,000",
                        PricePeriod = "one-time installation",
                        IsPopular = true,
                        Features = new List<string>
                        {
                            "Smart lighting (15 bulbs)",
                            "Smart thermostat",
                            "Smart door locks (2 units)",
                            "Security cameras (4 units)",
                            "Motion sensors (6 units)",
                            "Smart blinds/curtains (2 rooms)",
                            "Voice assistant setup (3 hubs)",
                            "Advanced automation & scenes",
                            "Energy monitoring",
                            "Professional installation",
                            "Comprehensive training",
                            "6 months priority support"
                        }
                    },
                    new ServicePackageModel
                    {
                        Id = "smart-premium",
                        ServiceType = "Smart Home",
                        PackageName = "Premium Package",
                        PackageSubtitle = "Luxury Smart Living",
                        IconClass = "fas fa-crown",
                        PriceRange = "R50,000+",
                        PricePeriod = "custom quote",
                        IsPopular = false,
                        ButtonText = "Contact Us",
                        Features = new List<string>
                        {
                            "Whole-home lighting automation",
                            "Multi-zone climate control",
                            "Advanced security system",
                            "Smart appliance integration",
                            "Home theater automation",
                            "Irrigation & garden automation",
                            "Smart garage door",
                            "Water leak detection",
                            "AI-powered scene learning",
                            "Custom dashboard design",
                            "Professional installation & setup",
                            "Extended training sessions",
                            "12 months premium support",
                            "Dedicated support manager"
                        }
                    }
                },
                TechStack = new List<TechStackItem>
                {
                    new TechStackItem { Name = "Google Home", IconClass = "fab fa-google", Category = "Voice" },
                    new TechStackItem { Name = "Alexa", IconClass = "fab fa-amazon", Category = "Voice" },
                    new TechStackItem { Name = "HomeKit", IconClass = "fab fa-apple", Category = "Voice" },
                    new TechStackItem { Name = "Zigbee", IconClass = "fas fa-network-wired", Category = "Protocol" },
                    new TechStackItem { Name = "Z-Wave", IconClass = "fas fa-wifi", Category = "Protocol" },
                    new TechStackItem { Name = "Home Assistant", IconClass = "fas fa-sitemap", Category = "Platform" },
                    new TechStackItem { Name = "Bluetooth", IconClass = "fab fa-bluetooth", Category = "Protocol" },
                    new TechStackItem { Name = "IFTTT", IconClass = "fas fa-mobile-alt", Category = "Automation" }
                }
            };
        }

        /// <summary>
        /// Get all service sections with updated pricing
        /// </summary>
        public static List<ServiceSectionModel> GetAllServiceSections()
        {
            return new List<ServiceSectionModel>
            {
                GetWebDevelopmentSection(),
                GetMobileAppsSection(),
                GetCloudAISection(),
                GetSmartHomeSection()
            };
        }
    }
}