using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CMS.PortalControls;
using CMS.GlobalHelper;
using CMS.CMSHelper;

public partial class CMSWebParts_Forums_Syndication_ForumPostsRSSFeed : CMSAbstractWebPart
{
    #region "RSS Feed Properties"

    /// <summary>
    /// Querystring key which is used for RSS feed identification on a page with multiple RSS feeds.
    /// </summary>
    public string QueryStringKey
    {
        get
        {
            return DataHelper.GetNotEmpty(ValidationHelper.GetString(GetValue("QueryStringKey"), null), rssFeed.QueryStringKey);
        }
        set
        {
            SetValue("QueryStringKey", value);
            rssFeed.QueryStringKey = value;
        }
    }


    /// <summary>
    /// Feed name to identify this feed on a page with multiple feeds. If the value is empty the GUID of the web part instance will be used by default.
    /// </summary>
    public string FeedName
    {
        get
        {
            return DataHelper.GetNotEmpty(ValidationHelper.GetString(GetValue("FeedName"), null), GetIdentificator());
        }
        set
        {
            string valueToSet = value;
            // If no feed name was specified
            if (string.IsNullOrEmpty(valueToSet))
            {
                // Set default name
                valueToSet = GetIdentificator();
            }
            SetValue("FeedName", valueToSet);
            rssFeed.FeedName = valueToSet;
        }
    }


    /// <summary>
    /// Text for the feed link.
    /// </summary>
    public string LinkText
    {
        get
        {
            return ValidationHelper.GetString(GetValue("LinkText"), string.Empty);
        }
        set
        {
            SetValue("LinkText", value);
            rssFeed.LinkText = value;
        }
    }


    /// <summary>
    /// Icon which will be displayed in the feed link.
    /// </summary>
    public string LinkIcon
    {
        get
        {
            return ValidationHelper.GetString(GetValue("LinkIcon"), string.Empty);
        }
        set
        {
            SetValue("LinkIcon", value);
            rssFeed.LinkIcon = value;
        }
    }


    /// <summary>
    /// Indicates if the RSS feed is automatically discovered by the browser.
    /// </summary>
    public bool EnableRSSAutodiscovery
    {
        get
        {
            return ValidationHelper.GetBoolean(GetValue("EnableRSSAutodiscovery"), true);
        }
        set
        {
            SetValue("EnableRSSAutodiscovery", value);
            rssFeed.EnableAutodiscovery = value;
        }
    }

    #endregion


    #region "RSS Repeater properties"

    /// <summary>
    /// URL title of the feed.
    /// </summary>
    public string FeedTitle
    {
        get
        {
            return ValidationHelper.GetString(GetValue("FeedTitle"), string.Empty);
        }
        set
        {
            SetValue("FeedTitle", value);
            rssFeed.FeedTitle = value;
        }
    }


    /// <summary>
    /// Description of the feed.
    /// </summary>
    public string FeedDescription
    {
        get
        {
            return ValidationHelper.GetString(GetValue("FeedDescription"), string.Empty);
        }
        set
        {
            SetValue("FeedDescription", value);
            rssFeed.FeedDescription = value;
        }
    }


    /// <summary>
    /// Language of the feed. If the value is empty the content culture will be used.
    /// </summary>
    public string FeedLanguage
    {
        get
        {
            string cultureCode = ValidationHelper.GetString(GetValue("FeedLanguage"), null);
            if (string.IsNullOrEmpty(cultureCode))
            {
                cultureCode = CMSContext.PreferredCultureCode;
            }
            return cultureCode;
        }
        set
        {
            SetValue("FeedLanguage", value);
            rssFeed.FeedLanguage = value;
        }
    }


    /// <summary>
    /// Custom feed header XML which is generated before feed items. If the value is empty default header for RSS feed is generated.
    /// </summary>
    public string HeaderXML
    {
        get
        {
            return ValidationHelper.GetString(GetValue("HeaderXML"), null);
        }
        set
        {
            SetValue("HeaderXML", value);
            rssFeed.HeaderXML = value;
        }
    }


    /// <summary>
    /// Custom feed footer XML which is generated after feed items. If the value is empty default footer for RSS feed is generated.
    /// </summary>
    public string FooterXML
    {
        get
        {
            return ValidationHelper.GetString(GetValue("FooterXML"), null);
        }
        set
        {
            SetValue("FooterXML", value);
            rssFeed.FooterXML = value;
        }
    }

    #endregion


    #region "Transformation properties"

    /// <summary>
    /// Gets or sets ItemTemplate property.
    /// </summary>
    public string TransformationName
    {
        get
        {
            return ValidationHelper.GetString(GetValue("TransformationName"), string.Empty);
        }
        set
        {
            SetValue("TransformationName", value);
            rssFeed.TransformationName = value;
        }
    }

    #endregion


    #region "Datasource properties"

    /// <summary>
    /// Gets or sets the web service URL.
    /// </summary>
    public string SiteName
    {
        get
        {
            return DataHelper.GetNotEmpty(this.GetValue("SiteName"), CMSContext.CurrentSiteName);
        }
        set
        {
            this.SetValue("SiteName", value);
            srcElem.SiteName = value;
        }
    }


    /// <summary>
    /// Gets or sets forum name for which blog posts should be obtained.
    /// </summary>
    public string ForumName
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("ForumName"), "");
        }
        set
        {
            this.SetValue("ForumName", value);
            srcElem.ForumName = value;
        }
    }


    /// <summary>
    /// Gets or sets Select only approved property.
    /// </summary>
    public bool SelectOnlyApproved
    {
        get
        {
            return ValidationHelper.GetBoolean(this.GetValue("SelectOnlyApproved"), true);
        }
        set
        {
            this.SetValue("SelectOnlyApproved", value);
            srcElem.SelectOnlyApproved = value;
        }
    }


    /// <summary>
    /// Gets or sets Check permissions property.
    /// </summary>
    public bool CheckPermissions
    {
        get
        {
            return ValidationHelper.GetBoolean(this.GetValue("CheckPermissions"), true);
        }
        set
        {
            this.SetValue("CheckPermissions", value);
            srcElem.CheckPermissions = value;
        }
    }

    
    /// <summary>
    /// Gets or sets the ORDER BY clause.
    /// </summary>
    public string OrderBy
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("OrderBy"), "");
        }
        set
        {
            this.SetValue("OrderBy", value);
            this.srcElem.OrderBy = value;
        }
    }


    /// <summary>
    /// Gets or sets the WHERE condition.
    /// </summary>
    public string WhereCondition
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("WhereCondition"), "");
        }
        set
        {
            this.SetValue("WhereCondition", value);
            this.srcElem.WhereCondition = value;
        }
    }


    /// <summary>
    /// Gets or sets the number which indicates how many documents should be displayed.
    /// </summary>
    public int SelectTopN
    {
        get
        {
            return ValidationHelper.GetInteger(this.GetValue("SelectTopN"), 0);
        }
        set
        {
            this.SetValue("SelectTopN", value);
            this.srcElem.TopN = value;
        }
    }


    /// <summary>
    /// Gets or sets the source filter name.
    /// </summary>
    public string FilterName
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("FilterName"), "");
        }
        set
        {
            this.SetValue("FilterName", value);
            srcElem.SourceFilterName = value;
        }
    }


    /// <summary>
    /// Gest or sets selected columns.
    /// </summary>
    public string Columns
    {
        get
        {
            return ValidationHelper.GetString(this.GetValue("Columns"), "");
        }
        set
        {
            this.SetValue("Columns", value);
            srcElem.SelectedColumns = value;
        }
    }


    /// <summary>
    /// Indicates if group posts should be included.
    /// </summary>
    public bool ShowGroupPosts
    {
        get
        {
            return ValidationHelper.GetBoolean(this.GetValue("ShowGroupPosts"), false);
        }
        set
        {
            this.SetValue("ShowGroupPosts", value);
            srcElem.ShowGroupPosts = value;
        }
    }

    #endregion


    #region "Cache properties"

    /// <summary>
    /// Gest or sets the cache item name.
    /// </summary>
    public override string CacheItemName
    {
        get
        {
            return base.CacheItemName;
        }
        set
        {
            base.CacheItemName = value;
            this.srcElem.CacheItemName = value;
            this.rssFeed.CacheItemName = value;
        }
    }


    /// <summary>
    /// Cache dependencies, each cache dependency on a new line.
    /// </summary>
    public override string CacheDependencies
    {
        get
        {
            return ValidationHelper.GetString(base.CacheDependencies, this.srcElem.CacheDependencies);
        }
        set
        {
            base.CacheDependencies = value;
            this.srcElem.CacheDependencies = value;
            this.rssFeed.CacheDependencies = value;
        }
    }


    /// <summary>
    /// Gets or sets the cache minutes.
    /// </summary>
    public override int CacheMinutes
    {
        get
        {
            return base.CacheMinutes;
        }
        set
        {
            base.CacheMinutes = value;
            this.srcElem.CacheMinutes = value;
            this.rssFeed.CacheMinutes = value;
        }
    }

    #endregion


    #region "Stop processing"

    /// <summary>
    /// Returns true if the control processing should be stopped.
    /// </summary>
    public override bool StopProcessing
    {
        get
        {
            return base.StopProcessing;
        }
        set
        {
            base.StopProcessing = value;
            rssFeed.StopProcessing = value;
            srcElem.StopProcessing = value;
        }
    }

    #endregion


    #region "Overidden methods"

    /// <summary>
    /// Content loaded event handler.
    /// </summary>
    public override void OnContentLoaded()
    {
        base.OnContentLoaded();
        SetupControl();
    }


    /// <summary>
    /// Reloads data.
    /// </summary>
    public override void ReloadData()
    {
        base.ReloadData();
        SetupControl();
    }

    #endregion


    #region "Setup control"

    /// <summary>
    /// Initializes the control properties.
    /// </summary>
    protected void SetupControl()
    {
        if (StopProcessing)
        {
            rssFeed.StopProcessing = true;
            srcElem.StopProcessing = true;
        }
        else
        {
            string feedCodeName = URLHelper.GetSafeUrlPart(FeedName, SiteName);
            // RSS feed properties
            rssFeed.FeedName = feedCodeName;
            rssFeed.FeedLink = URLHelper.GetAbsoluteUrl(URLHelper.AddParameterToUrl(URLHelper.CurrentURL, QueryStringKey, feedCodeName));
            rssFeed.LinkText = LinkText;
            rssFeed.LinkIcon = LinkIcon;
            rssFeed.FeedTitle = FeedTitle;
            rssFeed.FeedDescription = FeedDescription;
            rssFeed.FeedLanguage = FeedLanguage;
            rssFeed.EnableAutodiscovery = EnableRSSAutodiscovery;
            rssFeed.QueryStringKey = QueryStringKey;
            rssFeed.HeaderXML = HeaderXML;
            rssFeed.FooterXML = FooterXML;

            // Datasource properties
            srcElem.FilterName = ValidationHelper.GetString(this.GetValue("WebPartControlID"), this.ClientID);
            srcElem.SiteName = SiteName;
            srcElem.ForumName = ForumName;
            srcElem.OrderBy = OrderBy;
            srcElem.WhereCondition = WhereCondition;
            srcElem.TopN = SelectTopN;
            srcElem.SourceFilterName = FilterName;
            srcElem.SelectOnlyApproved = SelectOnlyApproved;
            srcElem.CheckPermissions = CheckPermissions;
            srcElem.SelectedColumns = Columns;
            srcElem.ShowGroupPosts = ShowGroupPosts;

            // Cache properties
            rssFeed.CacheItemName = CacheItemName;
            rssFeed.CacheDependencies = CacheDependencies;
            rssFeed.CacheMinutes = CacheMinutes;
            srcElem.CacheItemName = CacheItemName;
            srcElem.CacheDependencies = CacheDependencies;
            srcElem.CacheMinutes = CacheMinutes;

            // Transformation properties
            rssFeed.TransformationName = TransformationName;

            // Set datasource
            rssFeed.DataSourceControl = srcElem;
        }
    }

    #endregion
}
