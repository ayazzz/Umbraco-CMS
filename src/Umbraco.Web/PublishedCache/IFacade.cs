﻿using System;
using Umbraco.Core.Cache;

namespace Umbraco.Web.PublishedCache
{
    /// <summary>
    /// The Umbraco facade.
    /// </summary>
    public interface IFacade
    {
        /// <summary>
        /// Gets the <see cref="IPublishedContentCache"/>.
        /// </summary>
        IPublishedContentCache ContentCache { get; }

        /// <summary>
        /// Gets the <see cref="IPublishedMediaCache"/>.
        /// </summary>
        IPublishedMediaCache MediaCache { get; }

        /// <summary>
        /// Gets the <see cref="IPublishedMemberCache"/>.
        /// </summary>
        IPublishedMemberCache MemberCache { get; }

        /// <summary>
        /// Gets the <see cref="IDomainCache"/>.
        /// </summary>
        IDomainCache DomainCache { get; }

        /// <summary>
        /// Gets the facade cache.
        /// </summary>
        ICacheProvider FacadeCache { get; }

        /// <summary>
        /// Gets the snapshot cache.
        /// </summary>
        ICacheProvider SnapshotCache { get; }

        /// <summary>
        /// Forces the facade preview mode.
        /// </summary>
        /// <param name="preview">The forced preview mode.</param>
        /// <param name="callback">A callback to execute when reverting to previous preview.</param>
        /// <remarks>
        /// <para>Forcing to false means no preview. Forcing to true means 'full' preview if the facade is not already previewing;
        /// otherwise the facade keeps previewing according to whatever settings it is using already.</para>
        /// <para>Stops forcing preview when disposed.</para></remarks>
        IDisposable ForcedPreview(bool preview, Action<bool> callback = null);
    }
}
