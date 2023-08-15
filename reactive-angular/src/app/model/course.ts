export interface Course {
  id: string;
  description: string;
  longDescription: string;
  seqNo: number;
  iconUrl: string;
  price: number;
  uploadedImageUrl: string;
  courseListIcon: string;
  category: string;
  lessonsCount: number;
}

export function sortcourseBySeqno(c1:Course, c2:Course)
{
    return c1.seqNo - c2.seqNo;
}