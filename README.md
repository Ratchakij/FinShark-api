# ASP.NET Core + .NET 9 SDK + SQL Server

# Package install (EF Core Tools)
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson

# Create Migration and Upsate Database
dotnet ef migrations add InitialCreate
dotnet ef database update

# Topics
ASP.NET Core Web API .NET 8 2024 - 13. Comment GET + Include()

# SQL Query
1. INSERT Stocks
INSERT INTO Stocks (Symbol, CompanyName, Purchase, LastDiv, Industry, MarketCap)
VALUES
('AAPL', 'Apple Inc.', 150.00, 0.88, 'Technology', 2500000000000),
('GOOGL', 'Alphabet Inc.', 2800.00, 0.00, 'Technology', 1800000000000),
('MSFT', 'Microsoft Corporation', 300.00, 2.24, 'Technology', 2200000000000),
('AMZN', 'Amazon.com Inc.', 3400.00, 0.00, 'E-Commerce', 1700000000000),
('TSLA', 'Tesla Inc.', 700.00, 0.00, 'Automotive', 800000000000),
('FB', 'Meta Platforms Inc.', 350.00, 0.00, 'Technology', 900000000000),
('NVDA', 'NVIDIA Corporation', 200.00, 0.64, 'Technology', 500000000000),
('BRK.B', 'Berkshire Hathaway Inc.', 300.00, 0.00, 'Conglomerate', 600000000000),
('JNJ', 'Johnson & Johnson', 170.00, 4.24, 'Healthcare', 450000000000),
('V', 'Visa Inc.', 250.00, 1.28, 'Financial Services', 500000000000);

2. INSERT Comments
INSERT INTO [finshark].[dbo].[Comments] ([Title], [Content], [CreatedOn], [StockId], [AppUserId])
VALUES 
('Great Stock', 'This stock has shown consistent growth!', '2025-01-01 10:15:00', 1, 'user001'),
('Risky Investment', 'I am not sure about this one, it seems volatile.', '2025-01-01 11:30:00', 2, 'user002'),
('Solid Buy', 'This stock is undervalued. Strong buy.', '2025-01-01 12:00:00', 3, 'user003'),
('Overpriced', 'This stock is way too expensive right now.', '2025-01-02 09:45:00', 4, 'user004'),
('Good Dividend', 'I like this stock for its dividends.', '2025-01-02 13:20:00', 5, 'user005'),
('Bad Quarter', 'The recent earnings report was disappointing.', '2025-01-03 15:00:00', 6, 'user006'),
('Excellent Performance', 'The company is performing exceptionally well.', '2025-01-03 16:10:00', 7, 'user007'),
('Hold for Now', 'I recommend holding this stock for now.', '2025-01-04 14:30:00', 8, 'user008'),
('Underrated', 'This stock has a lot of potential that is not realized.', '2025-01-04 18:00:00', 9, 'user009'),
('Avoid This Stock', 'I don''t see any future for this stock.', '2025-01-05 10:25:00', 10, 'user010'),
('Potential Upside', 'If they get regulatory approval, the stock will soar.', '2025-01-05 12:45:00', 1, 'user011'),
('Steady Performer', 'Good stock for long-term investment.', '2025-01-06 08:00:00', 2, 'user012'),
('Sell Recommendation', 'I recommend selling this stock due to market trends.', '2025-01-06 09:15:00', 3, 'user013'),
('Sector Leader', 'This company is a leader in its industry.', '2025-01-07 11:30:00', 4, 'user014'),
('Overleveraged', 'The company is taking on too much debt.', '2025-01-07 13:50:00', 5, 'user015'),
('Promising Tech', 'Their new technology could disrupt the market.', '2025-01-08 07:45:00', 6, 'user016'),
('Insider Selling', 'High insider selling raises concerns.', '2025-01-08 09:30:00', 7, 'user017'),
('Market Leader', 'This is a safe and reliable stock.', '2025-01-09 10:00:00', 8, 'user018'),
('Growth Potential', 'The company is expanding into new markets.', '2025-01-09 12:15:00', 9, 'user019'),
('Negative Outlook', 'I expect the stock price to decline further.', '2025-01-10 11:40:00', 10, 'user020');

