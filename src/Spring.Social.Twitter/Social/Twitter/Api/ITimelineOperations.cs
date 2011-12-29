﻿#region License

/*
 * Copyright 2002-2011 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using System.IO;
using System.Collections.Generic;
#if NET_4_0 || SILVERLIGHT_5
using System.Threading.Tasks;
#endif

namespace Spring.Social.Twitter.Api
{
    /// <summary>
    /// Interface defining the operations for sending and retrieving tweets.
    /// </summary>
    /// <author>Craig Walls</author>
    /// <author>Bruno Baia (.NET)</author>
    public interface ITimelineOperations
    {
#if NET_4_0 || SILVERLIGHT_5
#else
#if !SILVERLIGHT
        /// <summary>
        /// Retrieves the 20 most recently posted tweets from the public timeline. 
        /// The public timeline is the timeline containing tweets from all Twitter users. 
        /// As this is the public timeline, authentication is not required to use this method.
        /// </summary>
        /// <remarks>
        /// Note that Twitter caches public timeline results for 60 seconds. 
        /// Calling this method more frequently than that will count against rate limits 
        /// and will not return any new results.
        /// </remarks>
        /// <returns>A list of <see cref="Tweet"/>s in the public timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetPublicTimeline();

        /// <summary>
        /// Retrieves the 20 most recently posted tweets, including retweets, from the authenticating user's home timeline. 
        /// The home timeline includes tweets from the user's timeline and the timeline of anyone that they follow.
        /// </summary>
        /// <returns>A list of <see cref="Tweet"/>s in the authenticating user's home timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetHomeTimeline();

        /// <summary>
        /// Retrieves tweets, including retweets, from the authenticating user's home timeline. 
        /// The home timeline includes tweets from the user's timeline and the timeline of anyone that they follow.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s in the authenticating user's home timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetHomeTimeline(int page, int pageSize);

        /// <summary>
        /// Retrieves tweets, including retweets, from the authenticating user's home timeline. 
        /// The home timeline includes tweets from the user's timeline and the timeline of anyone that they follow.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s in the authenticating user's home timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetHomeTimeline(int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieves the 20 most recent tweets posted by the authenticating user.
        /// </summary>
        /// <returns>A list of <see cref="Tweet"/>s that have been posted by the authenticating user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetUserTimeline();

        /// <summary>
        /// Retrieves tweets posted by the authenticating user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s that have been posted by the authenticating user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetUserTimeline(int page, int pageSize);

        /// <summary>
        /// Retrieves tweets posted by the authenticating user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been posted by the authenticating user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetUserTimeline(int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieves the 20 most recent tweets posted by the given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user whose timeline is being requested.</param>
        /// <returns>A list of <see cref="Tweet"/>s from the specified user's timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetUserTimeline(string screenName);

        /// <summary>
        /// Retrieves tweets posted by the given user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="screenName">The screen name of the user whose timeline is being requested.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s from the specified user's timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetUserTimeline(string screenName, int page, int pageSize);

        /// <summary>
        /// Retrieves tweets posted by the given user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="screenName">The screen name of the user whose timeline is being requested.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s from the specified user's timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetUserTimeline(string screenName, int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieves the 20 most recent tweets posted by the given user.
        /// </summary>
        /// <param name="userId">The user ID of the user whose timeline is being requested.</param>
        /// <returns>A list of <see cref="Tweet"/>s from the specified user's timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetUserTimeline(long userId);

        /// <summary>
        /// Retrieves tweets posted by the given user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="userId">The user ID of the user whose timeline is being requested.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s from the specified user's timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetUserTimeline(long userId, int page, int pageSize);

        /// <summary>
        /// Retrieves tweets posted by the given user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="userId">The user ID of the user whose timeline is being requested.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s from the specified user's timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetUserTimeline(long userId, int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieve the 20 most recent tweets that mention the authenticated user.
        /// </summary>
        /// <returns>A list of <see cref="Tweet"/>s that mention the authenticated user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetMentions();

        /// <summary>
        /// Retrieve tweets that mention the authenticated user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s that mention the authenticated user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetMentions(int page, int pageSize);

        /// <summary>
        /// Retrieve tweets that mention the authenticated user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 200. 
        /// (Will return at most 200 entries, even if pageSize is greater than 200)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s that mention the authenticated user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetMentions(int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieve the 20 most recent retweets posted by the authenticated user.
        /// </summary>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the authenticating user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByMe();

        /// <summary>
        /// Retrieve retweets posted by the authenticated user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the authenticating user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByMe(int page, int pageSize);

        /// <summary>
        /// Retrieve retweets posted by the authenticated user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the authenticating user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByMe(int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieve the 20 most recent retweets posted by the specified user.
        /// </summary>
        /// <param name="userId">The user ID to get retweets for.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the specified user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByUser(long userId);

        /// <summary>
        /// Retrieve retweets posted by the specified user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="userId">The user ID to get retweets for.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the specified user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByUser(long userId, int page, int pageSize);

        /// <summary>
        /// Retrieve retweets posted by the specified user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="userId">The user ID to get retweets for.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the specified user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByUser(long userId, int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieve the 20 most recent retweets posted by the specified user.
        /// </summary>
        /// <param name="screenName">The screen name of the user to get retweets for.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the specified user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByUser(string screenName);

        /// <summary>
        /// Retrieve retweets posted by the specified user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="screenName">The screen name of the user to get retweets for.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the specified user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByUser(string screenName, int page, int pageSize);

        /// <summary>
        /// Retrieve retweets posted by the specified user. The most recent tweets are listed first.
        /// </summary>
        /// <param name="screenName">The screen name of the user to get retweets for.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by the specified user.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedByUser(string screenName, int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieve the 20 most recent retweets posted by users the authenticating user follow.
        /// </summary>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users the authenticating user follow.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToMe();

        /// <summary>
        /// Retrieve retweets posted by users the authenticating user follow. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users the authenticating user follow.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToMe(int page, int pageSize);

        /// <summary>
        /// Retrieve retweets posted by users the authenticating user follow. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users the authenticating user follow.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToMe(int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieve the 20 most recent retweets posted by users that the specified user follows.
        /// </summary>
        /// <param name="userId">The user ID to get retweets for.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users that the specified user follows.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToUser(long userId);

        /// <summary>
        /// Retrieve retweets posted by users that the specified user follows. The most recent tweets are listed first.
        /// </summary>
        /// <param name="userId">The user ID to get retweets for.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users that the specified user follows.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToUser(long userId, int page, int pageSize);

        /// <summary>
        /// Retrieve retweets posted by users that the specified user follows. The most recent tweets are listed first.
        /// </summary>
        /// <param name="userId">The user ID to get retweets for.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users that the specified user follows.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToUser(long userId, int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieve the 20 most recent retweets by users that the specified user follows.
        /// </summary>
        /// <param name="screenName">The screen name of the user to get retweets for.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users that the specified user follows.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToUser(string screenName);

        /// <summary>
        /// Retrieve retweets by users that the specified user follows. The most recent tweets are listed first.
        /// </summary>
        /// <param name="screenName">The screen name of the user to get retweets for.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users that the specified user follows.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToUser(string screenName, int page, int pageSize);

        /// <summary>
        /// Retrieve retweets by users that the specified user follows. The most recent tweets are listed first.
        /// </summary>
        /// <param name="screenName">The screen name of the user to get retweets for.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s that have been 'retweeted' by users that the specified user follows.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetedToUser(string screenName, int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Retrieve the 20 most recent tweets of the authenticated user that have been retweeted by others.
        /// </summary>
        /// <returns>A list of <see cref="Tweet"/>s from the authenticated user that have been retweeted by others.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetsOfMe();

        /// <summary>
        /// Retrieve tweets of the authenticated user that have been retweeted by others. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of <see cref="Tweet"/>s from the authenticated user that have been retweeted by others.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetsOfMe(int page, int pageSize);

        /// <summary>
        /// Retrieve tweets of the authenticated user that have been retweeted by others. The most recent tweets are listed first.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="Tweet"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <param name="sinceId">The minimum <see cref="Tweet"/> ID to return in the results.</param>
        /// <param name="maxId">The maximum <see cref="Tweet"/> ID to return in the results.</param>
        /// <returns>A list of <see cref="Tweet"/>s from the authenticated user that have been retweeted by others.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetRetweetsOfMe(int page, int pageSize, long sinceId, long maxId);

        /// <summary>
        /// Returns a single tweet.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <returns>The <see cref="Tweet"/> from the specified ID.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        Tweet GetStatus(long tweetId);

        /// <summary>
        /// Updates the user's status.
        /// </summary>
        /// <param name="status">The status message.</param>
        /// <returns>The created <see cref="Tweet"/>.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="ApiException">If the status message duplicates a previously posted status.</exception>
        /// <exception cref="ApiException">If the length of the status message exceeds Twitter's 140 character limit.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        Tweet UpdateStatus(string status);

        /// <summary>
        /// Updates the user's status along with a picture.
        /// </summary>
        /// <param name="status">The status message.</param>
        /// <param name="photo">
        /// A <see cref="FileInfo"/> for the photo data. It must contain GIF, JPG, or PNG data.
        /// </param>
        /// <returns>The created <see cref="Tweet"/>.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="ApiException">If the status message duplicates a previously posted status.</exception>
        /// <exception cref="ApiException">If the length of the status message exceeds Twitter's 140 character limit.</exception>
        /// <exception cref="OperationNotPermittedException">If the photo resource isn't a GIF, JPG, or PNG.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        Tweet UpdateStatus(string status, FileInfo photo);

        /// <summary>
        /// Updates the user's status, including additional metadata concerning the status.
        /// </summary>
        /// <param name="status">The status message.</param>
        /// <param name="details">The metadata pertaining to the status.</param>
        /// <returns>The created <see cref="Tweet"/>.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="ApiException">If the status message duplicates a previously posted status.</exception>
        /// <exception cref="ApiException">If the length of the status message exceeds Twitter's 140 character limit.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        Tweet UpdateStatus(string status, StatusDetails details);

        /// <summary>
        /// Updates the user's status, including a picture and additional metadata concerning the status.
        /// </summary>
        /// <param name="status">The status message.</param>
        /// <param name="photo">
        /// A <see cref="FileInfo"/> for the photo data. It must contain GIF, JPG, or PNG data.
        /// </param>
        /// <param name="details">The metadata pertaining to the status.</param>
        /// <returns>The created <see cref="Tweet"/>.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="ApiException">If the status message duplicates a previously posted status.</exception>
        /// <exception cref="ApiException">If the length of the status message exceeds Twitter's 140 character limit.</exception>
        /// <exception cref="OperationNotPermittedException">If the photo resource isn't a GIF, JPG, or PNG.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        Tweet UpdateStatus(string status, FileInfo photo, StatusDetails details);

        /// <summary>
        /// Removes a status entry.
        /// </summary>
        /// <param name="tweetId">The tweet's ID to be removed.</param>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        void DeleteStatus(long tweetId);

        /// <summary>
        /// Posts a retweet of an existing tweet.
        /// </summary>
        /// <param name="tweetId">The tweet's ID to be retweeted.</param>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        void Retweet(long tweetId);

        /// <summary>
        /// Retrieves up to 100 retweets of a specific tweet.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <returns>The retweets of the specified tweet.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetRetweets(long tweetId);

        /// <summary>
        /// Retrieves retweets of a specific tweet.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <param name="count">
        /// The maximum number of retweets to return. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>The retweets of the specified tweet.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<Tweet> GetRetweets(long tweetId, int count);

        /// <summary>
        /// Retrieves the profiles of up to 100 users how have retweeted a specific tweet.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <returns>A list of <see cref="TwitterProfile">user's profiles</see> who have retweeted the specified tweet.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<TwitterProfile> GetRetweetedBy(long tweetId);

        /// <summary>
        /// Retrieves the profiles of users how have retweeted a specific tweet.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of <see cref="TwitterProfile"/>s per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of <see cref="TwitterProfile">user's profiles</see> who have retweeted the specified tweet.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        IList<TwitterProfile> GetRetweetedBy(long tweetId, int page, int pageSize);

        /// <summary>
        /// Retrieves the IDs of up to 100 users who have retweeted a specific tweet.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <returns>A list of <see cref="TwitterProfile">user's profiles</see> who have retweeted the specified tweet.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<long> GetRetweetedByIds(long tweetId);

        /// <summary>
        /// Retrieves the IDs of users who have retweeted a specific tweet.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">
        /// The number of entiers per page. Should be less than or equal to 100. 
        /// (Will return at most 100 entries, even if pageSize is greater than 100)
        /// </param>
        /// <returns>A list of user's ids who have retweeted the specified tweet.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<long> GetRetweetedByIds(long tweetId, int page, int pageSize);

        /// <summary>
        /// Retrieves the 20 most recent tweets favorited by the authenticated user.
        /// </summary>
        /// <returns>A list of <see cref="Tweet"/>s from the specified user's favorite timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetFavorites();

        /// <summary>
        /// Retrieves tweets favorited by the authenticated user.
        /// </summary>
        /// <param name="page">The page to return.</param>
        /// <param name="pageSize">The number of <see cref="Tweet"/>s per page.</param>
        /// <returns>A list of <see cref="Tweet"/>s from the specified user's favorite timeline.</returns>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        IList<Tweet> GetFavorites(int page, int pageSize);

        /// <summary>
        /// Adds a tweet to the user's collection of favorite tweets.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        void AddToFavorites(long tweetId);

        /// <summary>
        /// Removes a tweet from the user's collection of favorite tweets.
        /// </summary>
        /// <param name="tweetId">The tweet's ID.</param>
        /// <exception cref="ApiException">If there is an error while communicating with Twitter.</exception>
        /// <exception cref="NotAuthorizedException">If OAuth credentials was not provided.</exception>
        void RemoveFromFavorites(long tweetId);
#endif
#endif
    }
}