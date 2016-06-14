# Horse Racing Application. Iron Yard Rails Engineering Class 6/13/16

################################HORSE CLASS##################################

class Horse  

	def initialize
		@whisper = 0
		@whip = 0
		@kick = 0
		@race_speed = 0
		@breed = ""
		@breeds = {a: "thoroughbred", b: "quarter horse", c: "arabian", d: "paint",	e: "appaloosa"}
		
	end

	def race_speed_of_horse
		return @race_speed
	end

	def horse_demeaner(type)
		choice = false
		while choice == false
			if type == "thoroughbred"
				@whisper = 1
				@whip = 2
				@kick = 3
				#puts "You have the thoroughbred demeanor"
				choice = true
			elsif type == "quarter horse"
				@whisper = 3
				@whip = 1
				@kick = 2
				#puts "You have the quarter horse demeanor"
				choice = true
			elsif type == "arabian"
				@whisper = 2
				@whip = 3
				@kick = 1
				#puts "You have the arabian demeanor"
				choice = true
			elsif type == "paint"
				@whisper = 3
				@whip = 1
				@kick = 2
				#puts "You have the paint demeanor"
				choice = true
			elsif type == "appaloosa"
				@whisper = 3
				@whip = 1
				@kick = 3	
				#puts "You have the appaloosa demeanor"
				choice = true
			else
				puts "You need to select from the list."
			end
		end
		# puts "Your deamer is picked!" #debugging line
	end

	def horse_motivation(type)
		input = false
		while input == false
			if type == "w"
				if @whisper == 3
					@race_speed = 3
				elsif @whisper == 2
					@race_speed = 2	
				elsif @whisper == 1
					@race_speed = 1	
				end		
				input = true
			elsif type == "k"
				if @kick == 3
					@race_speed = 3
				elsif @kick== 2
					@race_speed = 2	
				elsif @kick == 1
					@race_speed = 1	
				end	
				input = true
			elsif type == "p"
				if @whip == 3
					@race_speed = 3
				elsif @whip == 2
					@race_speed = 2	
				elsif @whip == 1
					@race_speed = 1
				end	
				input = true
			else
				puts "That is not a valid input."
				puts "Please select from the following:  whisper(w), kick(k) or whip(p) him?(select a letter)"
				type = gets.chomp.downcase
			end
		end
		return @race_speed
	end

	def auto_horse_choose
			random_key = @breeds.keys
			@breed = @breeds[random_key.sample]
			return @breed
	end		

	def user_horse_selection
		puts "Select the letter of horse breed you want to race with:"
		@breeds.each { |a,b| puts "#{a.capitalize}: #{b.capitalize}"}
		type_choice = false
		while type_choice == false
			type = gets.chomp.downcase
			if type == "a"|| type == "b"|| type == "c"||type == "d"||type == "e"
				@breed = @breeds[:"#{type}"]
				type_choice = true
			else	
				puts "That is not a character option."	
			end	
		end	
		return @breed

	end
	
end	
###########################USER-RESPONSE CLASS###################################

class UserResponse

	def initialize
	end

	def user_output
		puts "The race is about to begin. How would you like to motivate your horse at the starting gate?:  whisper(w), kick(k) or whip(p) him?(select a letter)"
			answer = gets.chomp.downcase

			return answer
	end

	def user_output_option
		puts "How would you like to motivate your horse now?:  whisper(w), kick(k) or whip(p) him?(select a letter)"
			answer = gets.chomp.downcase

			return answer
	end		
end
################################RACETRACK CLASS##################################

class RaceTrack

	def initialize

			@auto_horses = {}
			@auto_horse_motivation_options = ["w", "k", "p"]
			@horse1_speed_calculation_ary = []
			@horse2_speed_calculation_ary = []
			@horse3_speed_calculation_ary = []
			@user_horse_speed_calculation_ary = []
			
	end

	def run_race

			100.times {puts ""}
			puts "You are racing against the following 3 horses:"
			@auto_horse_one = Horse.new
			@auto_horses[:a] = @auto_horse_one
			auto_horse_one_breed = @auto_horse_one.auto_horse_choose
			puts auto_horse_one_breed.capitalize
			@auto_horse_one.horse_demeaner("#{auto_horse_one_breed}")
			@auto_horse_one.horse_motivation(@auto_horse_motivation_options.sample)
			
			@auto_horses[:b] = (@auto_horse_two = Horse.new)
			auto_horse_two_breed = @auto_horse_two.auto_horse_choose
			puts auto_horse_two_breed.capitalize
			@auto_horse_two.horse_demeaner("#{auto_horse_two_breed}")
			@auto_horse_two.horse_motivation(@auto_horse_motivation_options.sample)

			@auto_horses[:c] = (@auto_horse_three = Horse.new)
			auto_horse_three_breed = @auto_horse_three.auto_horse_choose
			puts auto_horse_three_breed.capitalize
			@auto_horse_three.horse_demeaner("#{auto_horse_three_breed}")
			@auto_horse_three.horse_motivation(@auto_horse_motivation_options.sample)

			@user_horse = Horse.new
			user_horse_breed = @user_horse.user_horse_selection
			puts "Your horse selection is a:"
			puts user_horse_breed.capitalize
			user_horse_treatment = UserResponse.new
			@user_treatment_choice = user_horse_treatment.user_output
			@user_horse.horse_demeaner("#{user_horse_breed}")
			@user_horse.horse_motivation(@user_treatment_choice)
			race_over = false
			n = 0
			while race_over == false
				
				if n < 30
					self.start_race_progress
					@user_treatment_choice = user_horse_treatment.user_output_option
					@user_horse.horse_demeaner("#{user_horse_breed}")
					@user_horse.horse_motivation(@user_treatment_choice)
					100.times{puts""}
					n = n + 1

				else	
					race_over = true
				end	

			end
			self.end_race
	end

	def start_race_progress

			horse1_motivation_sample = @auto_horse_motivation_options.sample
			@auto_horse_one.horse_motivation(horse1_motivation_sample)
			@horse1_speed_calculation_ary.push("-"*@auto_horse_one.race_speed_of_horse)
			@horse1_speed_calculation_ary.each {|a| print a}
			print "Horse 1"
			puts ""

			horse2_motivation_sample = @auto_horse_motivation_options.sample
			@auto_horse_two.horse_motivation(horse2_motivation_sample)
			@horse2_speed_calculation_ary.push("-"*@auto_horse_two.race_speed_of_horse)
			@horse2_speed_calculation_ary.each {|a| print a}
			print "Horse 2"
			puts ""

			horse3_motivation_sample = @auto_horse_motivation_options.sample
			@auto_horse_three.horse_motivation(horse2_motivation_sample)
			@horse3_speed_calculation_ary.push("-"*@auto_horse_three.race_speed_of_horse)
			@horse3_speed_calculation_ary.each {|a| print a}
			print "Horse 3"
			puts ""
		
			@user_horse_speed_calculation_ary.push("-"*@user_horse.race_speed_of_horse)
			@user_horse_speed_calculation_ary.each {|a| print a}
			print "Your Horse"
			puts ""
		
	end

	def end_race

			@horse1_ary_stringed = @horse1_speed_calculation_ary.join("")
			@horse2_ary_stringed = @horse2_speed_calculation_ary.join("")
			@horse3_ary_stringed = @horse3_speed_calculation_ary.join("")
			@user_horse_ary_stringed = @user_horse_speed_calculation_ary.join("")

			if @user_horse_ary_stringed.length > @horse1_ary_stringed.length && @user_horse_ary_stringed.length > @horse2_ary_stringed.length && @user_horse_ary_stringed.length > @horse3_ary_stringed.length
				puts "Your Horse Won the Race! Great job motivating your horse!"

			else
				puts "You blew the race. You should know your horse better!"	
			end

	end

end		

RaceTrack.new.run_race

