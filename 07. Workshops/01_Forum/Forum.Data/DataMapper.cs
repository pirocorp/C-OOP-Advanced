﻿namespace Forum.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using DataModels;

    internal static class DataMapper
	{
		private const string DATA_PATH = "../../../../data/";
		private const string CONFIG_PATH = "config.ini";
		private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";

		private static readonly Dictionary<string, string> Config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            Config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

		private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var contents = ReadLines(configPath);

            var config = contents
                .Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }
        
        public static List<User> LoadUsers()
		{
			var users = new List<User>();
			var dataLines = ReadLines(Config["users"]);

			foreach (var line in dataLines)
			{
				var args = line.Split(';');
				var id = int.Parse(args[0]);
				var username = args[1];
				var password = args[2];
				var postIds = args[3]
					.Split(',', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				var user = new User(id, username, password, postIds);
				users.Add(user);
			}

			return users;
		}

		public static void SaveUsers(List<User> users)
		{
			var lines = new List<string>();

			foreach (var user in users)
			{
				const string userFormat = "{0};{1};{2};{3}";
				var line = string.Format(userFormat,
					user.Id,
					user.Username,
					user.Password,
					string.Join(",", user.Posts)
				);

				lines.Add(line);
			}

			WriteLines(Config["users"], lines.ToArray());
		}

		public static List<Category> LoadCategories()
		{
			var categories = new List<Category>();
			var dataLines = ReadLines(Config["categories"]);

			foreach (var line in dataLines)
			{
				var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
				var id = int.Parse(args[0]);
				var name = args[1];
                var postIds = args[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var category = new Category(id, name, postIds);
				categories.Add(category);
			}

			return categories;
		}

		public static void SaveCategories(List<Category> categories)
		{
			var lines = new List<string>();

			foreach (var category in categories)
			{
				const string categoryFormat = "{0};{1};{2}";
				var line = string.Format(categoryFormat,
					category.Id,
					category.Name,
					string.Join(",", category.Posts)
				);

				lines.Add(line);
			}

			WriteLines(Config["categories"], lines.ToArray());
		}

		public static List<Post> LoadPosts()
		{
			var posts = new List<Post>();
			var dataLines = ReadLines(Config["posts"]);

			foreach (var line in dataLines)
			{
				var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
				var id = int.Parse(args[0]);
				var title = args[1];
				var content = args[2];
				var categoryId = int.Parse(args[3]);
				var authorId = int.Parse(args[4]);
                var replies = new List<int>();
                if (args.Length == 6)
                {
                    replies.AddRange(args[5].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                }
				var post = new Post(id, title, content, categoryId, authorId, replies);

				posts.Add(post);
			}

			return posts;
		}

		public static void SavePosts(List<Post> posts)
		{
			var lines = new List<string>();
			foreach (var post in posts)
			{
				const string postFormat = "{0};{1};{2};{3};{4};{5}";
				var line = string.Format(postFormat,
					post.Id,
					post.Title,
					post.Content,
					post.CategoryId,
					post.AuthorId,
					string.Join(",", post.Replies)
				);
				lines.Add(line);
			}

			WriteLines(Config["posts"], lines.ToArray());
		}

		public static List<Reply> LoadReplies()
		{
			var replies = new List<Reply>();

			var dataLines = ReadLines(Config["replies"]);

			foreach (var line in dataLines)
			{
				var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
				var id = int.Parse(args[0]);
				var content = args[1];
				var authorId = int.Parse(args[2]);
				var postId = int.Parse(args[3]);

                replies.Add(new Reply(id, content, authorId, postId));
			}

			return replies;
		}

		public static void SaveReplies(List<Reply> replies)
		{
			var lines = new List<string>();

			foreach (var reply in replies)
			{
				const string replyFormat = "{0};{1};{2};{3}";
				var line = string.Format(replyFormat,
					reply.Id,
					reply.Content,
					reply.AuthorId,
					reply.PostId
				);
				lines.Add(line);
			}

			WriteLines(Config["replies"], lines.ToArray());
		}

		private static string[] ReadLines(string path)
		{
			EnsureFile(path);
			var lines = File.ReadAllLines(path);
			return lines;
		}
        
        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
		{
			if (!File.Exists(path))
			{
				File.Create(path).Close();
			}
		}

		private static void WriteLines(string path, string[] lines)
		{
			File.WriteAllLines(path, lines);
		}

	}
}
