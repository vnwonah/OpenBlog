using DotVVM.Framework.ViewModel;
using OpenBlog.Entities;
using OpenBlog.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBlog.ViewModels
{
	public class DefaultViewModel : MasterPageViewModel
    {
		[Bind(Direction.ServerToClient)]
		public IEnumerable<Post> Posts { get; set; }
		private PostService _postService;

		public DefaultViewModel(PostService postService)
		{
			_postService = postService;
		}

		public override async Task PreRender()
		{
			Posts = _postService.GetPostsAsync();
			await base.PreRender();
		}
	}
}
