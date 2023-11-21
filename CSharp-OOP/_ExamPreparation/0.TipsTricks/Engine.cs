        public Engine()
        {
			// Това се пише за да печата във файл
            this.writer = new FileWriter();
            this.reader = new Reader();
            this.controller = new Controller();
        }