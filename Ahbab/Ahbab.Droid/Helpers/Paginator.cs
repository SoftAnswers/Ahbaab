using System;
using System.Collections.Generic;
using Asawer.Entities;

namespace Asawer.Droid.Helpers {
    class Paginator {
        public static int TOTAL_NUM_ITEMS;
        public static int ITEMS_PER_PAGE = 10;
        public static int ITEMS_REMAINING;
        public static int LAST_PAGE;
        private List<User> searchResults;

        public Paginator(List<User> results) {
            this.searchResults = results;
            TOTAL_NUM_ITEMS = results.Count;
            ITEMS_REMAINING = TOTAL_NUM_ITEMS % ITEMS_PER_PAGE;
            LAST_PAGE = (int)Math.Ceiling((double)TOTAL_NUM_ITEMS / ITEMS_PER_PAGE);
        }

        /**
         * Function used to return the list of users to be displayed in 
         * a certain page
         */
        public List<User> GeneratePage(int currentPage) {
            int startItem = currentPage * ITEMS_PER_PAGE;
            int numOfData = ITEMS_PER_PAGE;

            List<User> pageData = new List<User>();

            if (currentPage == LAST_PAGE - 1 && ITEMS_REMAINING > 0) {
                for (int i = startItem; i < startItem + ITEMS_REMAINING; i++) {
                    pageData.Add(searchResults[i]);
                }
            } else {
                for (int i = startItem; i < startItem + numOfData; i++) {
                    pageData.Add(searchResults[i]);
                }
            }
            return pageData;
        }
    }
}