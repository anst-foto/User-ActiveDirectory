using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace User_ActiveDirectory_lib
{
    public class UserAD
    {
        //private const string username = "username";
        //private const string password = "password";
        private readonly string path;
        private DirectoryEntry domain;
        private DirectorySearcher search;
        private SearchResultCollection searchResultCollection;
        private SearchResult searchResult;

        public UserAD()
        {
            domain = new DirectoryEntry();
            search = new DirectorySearcher(domain);
        }

        public UserAD(string _path)
        {
            path = _path ?? throw new ArgumentNullException(nameof(_path));

            domain = new DirectoryEntry(path: path);
            search = new DirectorySearcher(domain);
        }

        public DirectoryEntry Domain { get; }//Возвращает значение переменной domain

        public DirectorySearcher Search { get; }//Возвращает значение переменной search

        public SearchResultCollection SearchResultCollection { get => searchResultCollection; set => searchResultCollection = value; }
        public SearchResult SearchResult { get => searchResult; set => searchResult = value; }

        public void Find(string _name)
        {
            search.Filter = "(&(&(objectClass=user)(objectClass=person))(cn={_name}))";
            search.PageSize = 1000;
            searchResultCollection = search.FindAll();
        }
    }
}
