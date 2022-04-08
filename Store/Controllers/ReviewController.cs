using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class ReviewController
    {
        private ReviewRepository reviewRepository;

        public ReviewController(stuff_shopContext db)
        {
            reviewRepository = new ReviewRepository(db);
        }

        public List<Review> GetAllReviews()
        {
            return reviewRepository.Items.ToList();
        }

        public void AddReview(Review review)
        {
            reviewRepository.Add(review);
        }

        async public Task UpdateReviewAsync(Review review)
        {
            await reviewRepository.UpdateAsync(review, new System.Threading.CancellationToken());
        }

        public void RemoveReview(int id)
        {
            reviewRepository.Remove(id);
        }

        public List<Review> GetReviewsForGood(Good good)
        {
            return reviewRepository.GetByGood(good).ToList();
        }
    }
}
