from pyspark.sql import SparkSession
from pyspark.sql.types import StructType, StructField, StringType, DoubleType
from solution.udfs import get_english_name, get_start_year, get_trend
from pyspark.sql.functions import col, udf

class BirdsETLJob:
    input_path = 'data/input/birds.csv'

    def __init__(self):
        self.spark_session = (SparkSession.builder
                                          .master("local[1]")
                                          .appName("BirdsETLJob")
                                          .getOrCreate())

        x = get_english_name('a (b)')

        self.spark_session.udf.register("get_english_name", udf(get_english_name, StringType()))

        self.spark_session.udf.register("get_start_year", udf(get_start_year, StringType()))

        self.spark_session.udf.register("get_trend", udf(get_trend, DoubleType()))

    def extract(self):
        input_schema = StructType([StructField("Species", StringType()),
                                   StructField("Category", StringType()),
                                   StructField("Period", StringType()),
                                   StructField("Annual percentage change", DoubleType())
                                   ])
        return self.spark_session.read.csv(self.input_path, header=True, schema=input_schema)

    def transform(self, df):
        transformed_row = df.withColumn('species', get_english_name(col('Species')))
        transformed_row = transformed_row.withColumn('category', col('Category'))      
        transformed_row = transformed_row.withColumn('collected_from_year', get_start_year(col('Period')))
        transformed_row = transformed_row.withColumn('annual_percentage_change', col('Annual percentage change'))
        transformed_row = transformed_row.withColumn('trend', get_trend(col('Annual percentage change').cast("double")))
        selected_df = transformed_row.select("species", "category", "collected_from_year", "annual_percentage_change" , "trend")
        return selected_df          

    def run(self):
        return self.transform(self.extract())


from pyspark.sql.functions import trim, split, col, when

def get_english_name(species):
    return trim(split(species, "\(")[0])


def get_start_year(period):
    return split(split(period, "\(")[0], "-")[0]


def get_trend(annual_percentage_change):
    value = annual_percentage_change
    return when((value < -3), "strong decline") \
        .when((value >= -3) & (value <= -0.5), "weak decline") \
        .when((value > -0.5) & (value < 0.5), "no change") \
        .when((value >= 0.5) & (value <= 3), "weak decline") \
        .otherwise("strong increase")

#transformed_row = transformed_row.withColumn('species', udf(get_english_name)(col('Species')))
#transformed_row = transformed_row.withColumn('collected_from_year', udf(get_start_year)(col('Period')))
#transformed_row = transformed_row.withColumn('trend', udf(get_trend)(col('Annual percentage change').cast("double")))